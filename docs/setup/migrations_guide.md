
# Database Migrations Guide

This guide explains how to manage database migrations for this project. It covers creating, applying, and rolling back migrations.

## Prerequisites

- **EF Core CLI**: Ensure you have the EF Core command-line tools installed.
  
  ```bash
  dotnet tool install --global dotnet-ef
  ```

- **Database Connection String**: Confirm that your connection string is correctly set in your environment variables or `appsettings.json`.

## Overview of Migration Commands

The following commands are available for managing migrations:

- `dotnet ef migrations add <MigrationName>`: Creates a new migration file.
- `dotnet ef database update`: Applies pending migrations to the database.
- `dotnet ef migrations remove`: Removes the latest migration.
- `dotnet ef database update <MigrationName>`: Rolls back to a specific migration.

---

## Creating a Migration

To create a migration, follow these steps:

1. Open a terminal in the project’s root directory.
2. Run the following command, replacing `<MigrationName>` with a descriptive name.

    ```bash

    dotnet ef migrations add <MigrationName> --project <YourDbContextProject> --startup-project <YourStartupProject>

    ```

3. A new migration file will be created under `Migrations` folder. Review this file to ensure the changes are correct.

    ```bash

    cd ..\CleanArchitecture.Template.Infrastructure
    dotnet ef migrations add AddUserTable --context ApplicationDbContext --startup-project ..\CleanArchitecture.Template.Host
    ```

---

## Applying Migrations

To apply all pending migrations and update the database, use the following command:

```bash
dotnet ef database update --context <YourDbContextFilet> --startup-project <YourStartupProject>
```

**Example**:

```bash

dotnet ef database update --context ApplicationDbContext --startup-project ..\CleanArchitecture.Template.Host
```

### Applying Specific Migrations

If you need to apply a specific migration (e.g., during a rollback), specify the migration name:

```bash
dotnet ef database update <MigrationName> --context <YourDbContextFilet> --startup-project <YourStartupProject>
```

---

## Removing the Latest Migration

If a migration was created by mistake or contains errors, you can remove it:

```bash
dotnet ef migrations remove --context <YourDbContextFilet> --startup-project <YourStartupProject>
```

**Note**: This command will only work if the migration has not yet been applied to the database.

---

## Rolling Back a Migration

To roll back the database to a specific migration, use:

```bash
dotnet ef database update <MigrationName> --context <YourDbContextFilet> --startup-project <YourStartupProject>
```

To revert all migrations (reset the database):

```bash
dotnet ef database update 0 --context <YourDbContextFilet> --startup-project <YourStartupProject>
```

---

## Verifying Migration Status

You can check which migrations have been applied and which are pending by running:

```bash
dotnet ef migrations list --context <YourDbContextFilet> --startup-project <YourStartupProject>
```

---

## Common Issues and Troubleshooting

- **Connection Issues**: Ensure the connection string is properly configured in `appsettings.json` or environment variables or on the host: **project => Manage User Secrets.**
- **Migration Conflicts**: If migrations conflict (e.g., multiple developers working simultaneously), rebase to include the latest migrations from your main branch, then recreate or update migrations.

---

## Best Practices

- **Descriptive Names**: Use descriptive names for migrations (e.g., `AddUserTable` or `UpdateOrderStatus`).
- **Review Migrations**: Always review the generated migration files before applying them.
- **Frequent Commits**: Commit each migration with a relevant message to track schema changes in version control.

---

For more details, see the [EF Core Migrations Documentation](https://docs.microsoft.com/ef/core/managing-schemas/migrations/).
