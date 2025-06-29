using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.CreatedBy).HasMaxLength(32);
            builder.Property(c => c.UpdatedBy).HasMaxLength(32);
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.IsDeleted).HasDefaultValueSql("0");
            builder.Property(c => c.Active).HasDefaultValueSql("1");

            builder.HasOne<ArticleTranslation>()
                   .WithMany()
                   .HasForeignKey(c => c.ArticleTranslationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
