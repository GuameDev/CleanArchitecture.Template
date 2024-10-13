using CleanArchitecture.Template.Domain.Users;
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

            builder.OwnsOne(user => user.Email, email =>
                {
                    email.Property(email => email.Value)
                    .HasColumnName(nameof(User.Email))
                    .IsRequired();
                });

            builder.OwnsOne(user => user.Username, username =>
            {
                username.Property(username => username.Value)
                .HasColumnName(nameof(User.Username))
                .IsRequired();
            });

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
            builder.HasMany(r => r.Roles)
               .WithMany()
               .UsingEntity<Dictionary<string, object>>(
                    UserConstantsEntityTypeConfiguration.UserRolesTableName, // The join table name remains as a string
                    j => j.HasOne<Role>().WithMany().HasForeignKey(UserConstantsEntityTypeConfiguration.RoleIdColumnName),
                    j => j.HasOne<User>().WithMany().HasForeignKey(UserConstantsEntityTypeConfiguration.UserIdColumnName),
                    j =>
                    {
                        j.Property<int>(UserConstantsEntityTypeConfiguration.UserRolePrimaryKeyColumnName)
                            .ValueGeneratedOnAdd();
                        j.HasKey(UserConstantsEntityTypeConfiguration.UserRolePrimaryKeyColumnName);
                    }
               );


        }
    }
}
