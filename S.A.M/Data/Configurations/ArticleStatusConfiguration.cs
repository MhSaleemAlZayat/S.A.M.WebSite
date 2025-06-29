using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;
public class ArticleStatusConfiguration : IEntityTypeConfiguration<ArticleStatus>
{
    public void Configure(EntityTypeBuilder<ArticleStatus> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasConversion<byte>().IsRequired();
        builder.Property(s => s.Name).HasConversion<string>().IsRequired().HasMaxLength(64);
        builder.Property(s => s.Description).HasMaxLength(256);


        builder.HasMany(s => s.ArticleStatusTransactions)
            .WithOne()
            .HasForeignKey(a => a.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public static class ArticleStatusSeed
{
    public static void SeedArticleStatusValues(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticleStatus>().HasData(new ArticleStatus[]
        {
            new ArticleStatus
            {
                Id = ArticleStatus.ArticleStatusEnum.Draft,
                Name = ArticleStatus.ArticleStatusEnum.Draft,
                Description = "مسودة: غير جاهز للنشر."
            },
            new ArticleStatus
            {
                Id = ArticleStatus.ArticleStatusEnum.Pending,
                Name = ArticleStatus.ArticleStatusEnum.Pending,
                Description = "بانتظار المراجعة: في انتظار المراجعة قبل النشر."
            },
            new ArticleStatus
            {
                Id = ArticleStatus.ArticleStatusEnum.Published,
                Name = ArticleStatus.ArticleStatusEnum.Published,
                Description = "منشور: تم نشره ويمكن الوصول إليه من قبل الجميع."
            },
            new ArticleStatus
            {
                Id = ArticleStatus.ArticleStatusEnum.Private,
                Name = ArticleStatus.ArticleStatusEnum.Private,
                Description = "خاص: مرئية فقط لمسؤولي الموقع والمحررين."
            },
            new ArticleStatus
            {
                Id = ArticleStatus.ArticleStatusEnum.Scheduled,
                Name = ArticleStatus.ArticleStatusEnum.Scheduled,
                Description = "مجدول: مخطط للنشر في وقت لاحق."
            }
        });
    }
}
