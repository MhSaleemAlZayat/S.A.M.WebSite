using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {
            builder.HasKey(at => new { at.ArticleId, at.TagId });

            builder.HasOne(at => at.Article)
                   .WithMany()
                   .HasForeignKey(at => at.ArticleId);

            builder.HasOne(at => at.Tag)
                   .WithMany()
                   .HasForeignKey(at => at.TagId);
        }
    }
}
