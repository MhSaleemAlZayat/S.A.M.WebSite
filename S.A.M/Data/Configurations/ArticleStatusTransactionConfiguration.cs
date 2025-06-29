using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;

public class ArticleStatusTransactionConfiguration : IEntityTypeConfiguration<ArticleStatusTransaction>
{
    public void Configure(EntityTypeBuilder<ArticleStatusTransaction> builder)
    {
        builder.HasKey(ast => ast.Id);
        builder.Property(ast => ast.ArticleTranslationId).IsRequired();
        builder.Property(ast => ast.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        builder.Property(ast => ast.CreatedBy).IsRequired();
        builder.Property(ast => ast.StatusId).IsRequired();

        builder.HasOne(ast => ast.ArticleTranslation)
            .WithMany(a => a.StatusTransactions)
            .HasForeignKey(ast => ast.ArticleTranslationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
