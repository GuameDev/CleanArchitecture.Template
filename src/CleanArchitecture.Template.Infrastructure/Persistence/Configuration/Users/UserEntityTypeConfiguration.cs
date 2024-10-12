using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users
{
    public class UserEntityTypeConfiguration : BaseEntityConfiguration<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder); // Apply the base configurations

            // Configure specific properties for User
            builder.Property(u => u.Username)
                .HasConversion(username => username.Value, value => Username.Create(value).Value)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasConversion(email => email.Value, value => Email.Create(value).Value)
                .IsRequired();

            // Map FullName to individual columns for each part
            builder.OwnsOne(u => u.FullName, fullName =>
            {
                fullName.Property(fn => fn.FirstName)
                    .HasColumnName(nameof(FullName.FirstName))
                    .IsRequired();

                fullName.Property(fn => fn.LastName1)
                    .HasColumnName(nameof(FullName.LastName1))
                    .IsRequired();

                fullName.Property(fn => fn.LastName2)
                    .HasColumnName(nameof(FullName.LastName2))
                    .IsRequired(false);
            });

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true);

            // Configure the many-to-many relationship between User and Role
            builder.HasMany(u => u.Roles)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    UserConstantsEntityTypeConfiguration.UserRolesTableName, // The join table name remains as a string
                    j => j.HasOne<Role>().WithMany().HasForeignKey(UserConstantsEntityTypeConfiguration.RoleIdColumnName),
                    j => j.HasOne<User>().WithMany().HasForeignKey(UserConstantsEntityTypeConfiguration.UserIdColumnName)
                );
        }
    }
}
