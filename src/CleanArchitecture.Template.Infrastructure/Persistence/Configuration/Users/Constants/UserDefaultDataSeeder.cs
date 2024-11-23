using CleanArchitecture.Template.Domain.Users.Aggregates.Permissions;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users.Constants;
using Microsoft.EntityFrameworkCore;

public static class UserDefaultDataSeeder
{
    // Pre-generated random GUIDs, hard-coded to avoid migration changes
    public static readonly Guid AdminRoleId = Guid.Parse("a37f1b12-6d0c-4d52-a4e5-b84adf6d184c");
    public static readonly Guid UserRoleId = Guid.Parse("b2e8e3f6-c8f1-45db-8c7a-a7e14c680bfb");

    public static readonly Guid ReadPermissionId = Guid.Parse("c3c11234-56b8-4e89-91f4-21e1e69e76fa");
    public static readonly Guid WritePermissionId = Guid.Parse("d4b732bc-0a9d-420f-8c2d-5911dbe24d6d");
    public static readonly Guid ManageUsersPermissionId = Guid.Parse("e5f01b6d-1b3e-4919-9b24-7c3e61f1f91b");
    public static readonly Guid ManageRolesPermissionId = Guid.Parse("f6027a94-318d-4d13-b78f-9277cd3f7086");
    public static readonly Guid ViewDashboardPermissionId = Guid.Parse("a8b61357-15f2-48a1-9114-2d2d885de8c1");


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
