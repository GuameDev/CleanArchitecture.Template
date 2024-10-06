using CleanArchitecture.Template.Domain.Users.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration
{
    public class RoleEntityTypeConfiguration : BaseEntityConfiguration<Role, Guid>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            // Configure RoleName to be stored as string
            builder.Property(r => r.RoleName)
                .HasConversion(
                    roleName => roleName.ToString(),      // To database as string
                    roleName => (RoleName)Enum.Parse(typeof(RoleName), roleName)) // From string to enum
                .IsRequired();

            // Many-to-many relationship with Permissions
            builder.HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RolePermissions", // The join table name
                    rp => rp.HasOne<Permission>().WithMany().HasForeignKey("PermissionId"),
                    rp => rp.HasOne<Role>().WithMany().HasForeignKey("RoleId")
                );

            SeedDefaultRoles(builder);
        }

        private void SeedDefaultRoles(EntityTypeBuilder<Role> builder)
        {
            var now = DateTime.UtcNow;
            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            // Seed using string representation of the enum
            var roles = new List<object>
            {
                new { Id = adminRoleId, RoleName = RoleName.Admin, CreatedDate = now, UpdatedDate = now },
                new { Id = userRoleId, RoleName = RoleName.User, CreatedDate = now, UpdatedDate = now }
            };

            builder.HasData(roles);
        }
    }
}
