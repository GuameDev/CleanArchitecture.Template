using CleanArchitecture.Template.Domain.Users.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Configuration.Users
{
    public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable(UserConstantsEntityTypeConfiguration.RefreshTokenTableName);

            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id)
                .ValueGeneratedOnAdd();

            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(UserConstantsEntityTypeConfiguration.RefreshToken_CreatedAtMaxLength);

            builder.Property(rt => rt.ExpirationDate)
                .IsRequired();

            builder.Property(rt => rt.CreatedAt)
               .IsRequired();

            builder.Property(rt => rt.LastUsed)
                .IsRequired(false);

            builder.Property(rt => rt.IsRevoked)
                .HasDefaultValue(false);


            builder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
