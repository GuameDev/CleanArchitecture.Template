using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration
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
                    .HasColumnName("FirstName")
                    .IsRequired();

                fullName.Property(fn => fn.LastName1)
                    .HasColumnName("LastName1")
                    .IsRequired();

                fullName.Property(fn => fn.LastName2)
                    .HasColumnName("LastName2")
                    .IsRequired(false); // Nullable for LastName2
            });

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true);

            // Correct the many-to-many relationship with roles using a join table
            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users) // This creates a many-to-many relationship
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoles", // The join table name
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
                );
        }
    }
}
