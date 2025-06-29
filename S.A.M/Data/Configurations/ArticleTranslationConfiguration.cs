using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;

public class ArticleTranslationConfiguration : IEntityTypeConfiguration<ArticleTranslation>
{
    public void Configure(EntityTypeBuilder<ArticleTranslation> builder)
    {
        builder.HasKey(at => at.Id);
        builder.Property(a => a.Title).IsRequired().HasMaxLength(256);
        builder.Property(a => a.Slug).IsRequired().HasMaxLength(256);
        builder.Property(a => a.Content).IsRequired();
        builder.Property(a => a.FeatureImageUrl).HasMaxLength(512);
        builder.Property(at => at.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(c => c.IsDeleted).HasDefaultValueSql("0");
        builder.Property(c => c.Active).HasDefaultValueSql("1");

        builder.HasMany(a => a.StatusTransactions)
                .WithOne(ast => ast.ArticleTranslation)
                .HasForeignKey(ast => ast.ArticleTranslationId)
                .OnDelete(DeleteBehavior.Restrict);

    }
}
