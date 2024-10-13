namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users
{
    public static class UserConstantsEntityTypeConfiguration
    {
        //Table names
        public const string UserRolesTableName = "UserRoles";
        public const string RolePermissionsTableName = "RolePermissions";

        //Column names
        public const string RolePermissionsColumnName = "RolePermissions";
        public const string RoleIdColumnName = "RoleId";
        public const string UserIdColumnName = "UserId";
        public const string PermissionIdColumnName = "PermissionId";
        public const string RolePermissionPrimaryKeyColumnName = "Id";
        public const string UserRolePrimaryKeyColumnName = "Id";
    }
}
