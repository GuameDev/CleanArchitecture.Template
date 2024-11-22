using CleanArchitecture.Template.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration
{
    public abstract class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
           where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Base configuration for all entities inheriting from BaseEntity
            builder.Property(e => e.CreatedDate)
                .IsRequired();

            builder.Property(e => e.UpdatedDate)
                .IsRequired();

            builder.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        }
    }
}