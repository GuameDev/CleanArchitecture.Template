using CleanArchitecture.Template.Domain.Users.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users
{
    public class RoleEntityTypeConfiguration : BaseEntityConfiguration<Role, Guid>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            // Configure RoleName to be stored as a string using expression-based conversion
            builder.Property(r => r.RoleName)
                .HasConversion(
                    roleName => roleName.ToString(),
                    roleName => (RoleName)Enum.Parse(typeof(RoleName), roleName))
                .IsRequired();

            // Configure many-to-many relationship between Roles and Permissions
            builder.HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    UserConstantsEntityTypeConfiguration.RolePermissionsTableName,
                    j => j.HasOne<Permission>().WithMany().HasForeignKey(UserConstantsEntityTypeConfiguration.PermissionIdColumnName),
                    j => j.HasOne<Role>().WithMany().HasForeignKey(UserConstantsEntityTypeConfiguration.RoleIdColumnName)
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
