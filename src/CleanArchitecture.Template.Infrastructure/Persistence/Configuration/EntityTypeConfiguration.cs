using CleanArchitecture.Template.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration
{
    public abstract class EntityTypeConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
           where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Base configuration for all entities inheriting from BaseEntity
            builder
                .HasKey(entity => entity.Id);

            builder.Property(entity => entity.CreatedDate)
                .IsRequired();

            builder.Property(entity => entity.UpdatedDate)
                .IsRequired();

            builder.Property(entity => entity.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

        }
    }
}