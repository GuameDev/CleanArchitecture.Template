using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users
{
    public class PermissionEntityTypeConfiguration : BaseEntityConfiguration<Permission, Guid>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            // No need to explicitly configure the Role-Permission relationship since it's handled by the RoleEntityTypeConfiguration

            SeedDefaultPermissions(builder);
        }

        private void SeedDefaultPermissions(EntityTypeBuilder<Permission> builder)
        {
            var now = DateTime.UtcNow;
            var permissions = new List<object>
            {
                new { Id = Guid.NewGuid(), Name = "Read", Description = "Can read data", CreatedDate = now, UpdatedDate = now },
                new { Id = Guid.NewGuid(), Name = "Write", Description = "Can modify data", CreatedDate = now, UpdatedDate = now },
                new { Id = Guid.NewGuid(), Name = "ManageUsers", Description = "Can manage users", CreatedDate = now, UpdatedDate = now },
                new { Id = Guid.NewGuid(), Name = "ManageRoles", Description = "Can manage roles and permissions", CreatedDate = now, UpdatedDate = now },
                new { Id = Guid.NewGuid(), Name = "ViewDashboard", Description = "Can view the dashboard", CreatedDate = now, UpdatedDate = now }
            };

            builder.HasData(permissions);
        }
    }
}
