using CleanArchitecture.Template.Domain.Users.Aggregates;
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


        }
    }
}
