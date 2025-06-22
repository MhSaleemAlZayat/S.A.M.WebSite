using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.FeatureImageUrl).HasMaxLength(512);
            builder.Property(p => p.CreatedBy).HasMaxLength(32);
            builder.Property(p => p.UpdatedBy).HasMaxLength(32);
            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
