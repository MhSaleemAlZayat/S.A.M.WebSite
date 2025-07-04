using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FileName).IsRequired().HasMaxLength(256);
            builder.Property(m => m.Url).IsRequired().HasMaxLength(512);
            builder.Property(m => m.FilePath).HasMaxLength(1024);
            builder.Property(m => m.Description).HasMaxLength(512);
            builder.Property(m => m.AlternativeText).HasMaxLength(256);
            builder.Property(m => m.ContentType).HasMaxLength(128);
            builder.Property(m => m.CreatedBy).HasMaxLength(36);;
            builder.Property(m => m.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
