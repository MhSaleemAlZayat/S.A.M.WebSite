using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class TagTranslationConfiguration : IEntityTypeConfiguration<TagTranslation>
    {
        public void Configure(EntityTypeBuilder<TagTranslation> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(64);
            builder.Property(t => t.Slug).HasMaxLength(128);
            builder.Property(t => t.TagId).IsRequired();
            builder.Property(t => t.LanguageId).IsRequired();
            builder.Property(t => t.CreatedBy).HasMaxLength(32);
            builder.Property(t => t.UpdatedBy).HasMaxLength(32);
            builder.Property(t => t.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.IsDeleted).HasDefaultValueSql("0");
            builder.Property(c => c.Active).HasDefaultValueSql("1");
        }
    }
}
