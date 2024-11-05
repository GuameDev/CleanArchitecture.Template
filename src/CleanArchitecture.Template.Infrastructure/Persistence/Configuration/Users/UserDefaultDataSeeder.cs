using CleanArchitecture.Template.Domain.Users.Aggregates;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users;
using Microsoft.EntityFrameworkCore;

public static class UserDefaultDataSeeder
{
    public static readonly Guid AdminRoleId = Guid.NewGuid();
    public static readonly Guid UserRoleId = Guid.NewGuid();

    public static readonly Guid ReadPermissionId = Guid.NewGuid();
    public static readonly Guid WritePermissionId = Guid.NewGuid();
    public static readonly Guid ManageUsersPermissionId = Guid.NewGuid();
    public static readonly Guid ManageRolesPermissionId = Guid.NewGuid();
    public static readonly Guid ViewDashboardPermissionId = Guid.NewGuid();

    public static void Seed(ModelBuilder modelBuilder)
    {
        var now = DateTime.UtcNow;

        // Seed roles
        modelBuilder.Entity<Role>().HasData(
            new { Id = AdminRoleId, RoleName = RoleName.Admin, CreatedDate = now, UpdatedDate = now },
            new { Id = UserRoleId, RoleName = RoleName.User, CreatedDate = now, UpdatedDate = now }
        );

        // Seed permissions using the PermissionType enum
        modelBuilder.Entity<Permission>().HasData(
            new { Id = ReadPermissionId, Type = PermissionType.Read, Description = "Can read data", CreatedDate = now, UpdatedDate = now },
            new { Id = WritePermissionId, Type = PermissionType.Write, Description = "Can modify data", CreatedDate = now, UpdatedDate = now },
            new { Id = ManageUsersPermissionId, Type = PermissionType.ManageUsers, Description = "Can manage users", CreatedDate = now, UpdatedDate = now },
            new { Id = ManageRolesPermissionId, Type = PermissionType.ManageRoles, Description = "Can manage roles and permissions", CreatedDate = now, UpdatedDate = now },
            new { Id = ViewDashboardPermissionId, Type = PermissionType.ViewDashboard, Description = "Can view the dashboard", CreatedDate = now, UpdatedDate = now }
        );

        // Seed many-to-many relationships for RolePermissions
        modelBuilder.Entity(UserConstantsEntityTypeConfiguration.RolePermissionsTableName).HasData(
            new { Id = 1, RoleId = AdminRoleId, PermissionId = ReadPermissionId },
            new { Id = 2, RoleId = AdminRoleId, PermissionId = WritePermissionId },
            new { Id = 3, RoleId = AdminRoleId, PermissionId = ManageUsersPermissionId },
            new { Id = 4, RoleId = AdminRoleId, PermissionId = ManageRolesPermissionId },
            new { Id = 5, RoleId = AdminRoleId, PermissionId = ViewDashboardPermissionId },
            new { Id = 6, RoleId = UserRoleId, PermissionId = ReadPermissionId }
        );
    }
}
