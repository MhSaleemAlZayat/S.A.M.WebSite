using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Slug).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.FeatureImageUrl).HasMaxLength(512);
            builder.Property(a => a.AuthorId).HasMaxLength(64);
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
