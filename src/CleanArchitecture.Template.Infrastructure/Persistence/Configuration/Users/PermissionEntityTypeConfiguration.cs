using CleanArchitecture.Template.Domain.Users.Aggregates.Permissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users
{
    public class PermissionEntityTypeConfiguration : BaseEntityConfiguration<Permission, Guid>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Type)
              .HasConversion(
                  v => v.ToString(),
                  v => (PermissionType)Enum.Parse(typeof(PermissionType), v))
              .IsRequired();

            builder.Property(p => p.Description).IsRequired();


        }
    }
}
