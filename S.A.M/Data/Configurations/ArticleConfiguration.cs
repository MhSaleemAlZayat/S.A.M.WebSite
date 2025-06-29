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

            builder.Property(a => a.AuthorId).HasMaxLength(32);

            builder.Property(a => a.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(a => a.Translations)
                .WithOne(ast => ast.Article)
                .HasForeignKey(ast => ast.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
