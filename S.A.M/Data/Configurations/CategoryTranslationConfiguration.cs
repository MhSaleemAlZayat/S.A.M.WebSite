using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;

public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
{
    public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(128);
        builder.Property(c => c.Slug).HasMaxLength(256);
        builder.Property(c => c.Description).HasMaxLength(512);
        builder.Property(c => c.CategoryId).IsRequired();
        builder.Property(c => c.LanguageId).IsRequired();
        builder.Property(c => c.CreatedBy).HasMaxLength(36);;
        builder.Property(c => c.UpdatedBy).HasMaxLength(36);;
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(c => c.IsDeleted).HasDefaultValueSql("0");
        builder.Property(c => c.Active).HasDefaultValueSql("1");
    }
}

public static class CategoryTranslationSeed
{
    public static void SeedCategoryTranslationValues(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryTranslation>().HasData(new CategoryTranslation[]
        {

            new CategoryTranslation
            {
                Id = 1,
                CategoryId = 1,
                LanguageId = 1,
                Name = "السياسة",
                Slug = "السياسة",
                Description = "تصنيف خاص بالمقالات السياسية.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 2,
                CategoryId = 1,
                LanguageId = 2,
                Name = "Politics",
                Slug = "Politics",
                Description = "Special category for political articles.",

                CreatedBy = "system",
            },
             new CategoryTranslation
            {
                Id = 3,
                CategoryId = 2,
                LanguageId = 1,
                Name = "التعليم",
                Slug = "التعليم",
                Description = "تصنيف خاص بالمقالات المتعلقة بالتعليم.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 4,
                CategoryId = 2,
                LanguageId = 2,
                Name = "Education",
                Slug = "Education",
                Description = "Category for articles related to education.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 5,
                CategoryId = 3,
                LanguageId = 1,
                Name = "الإقتصاد",
                Slug = "Economy",
                Description = "تصنيف خاص بالمقالات التي تتناول الشأن الإقتصادي السوري.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 6,
                CategoryId = 3,
                LanguageId = 2,
                Name = "Politics",
                Slug = "Politics",
                Description = "A special category for articles dealing with the Syrian economic issue.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 7,
                CategoryId = 4,
                LanguageId = 1,
                Name = "دولي",
                Slug = "دولي",
                Description = "تصنيف خاص بالمقالات الخاصة بالشأن الدولي.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 8,
                CategoryId = 4,
                LanguageId = 2,
                Name = "International",
                Slug = "International",
                Description = "Special category for articles on international affairs.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 9,
                CategoryId = 5,
                LanguageId = 1,
                Name = "غير مصنف",
                Slug = "غير مصنف",
                Description = "المقالات غير المصنفة.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 10,
                CategoryId = 5,
                LanguageId = 2,
                Name = "Uncategorized",
                Slug = "uncategorized",
                Description = "Uncategorized articles.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 11,
                CategoryId = 6,
                LanguageId = 1,
                Name = "أرشيف",
                Slug = "أرشيف",
                Description = "المقالات التي تم أرشفتها.",

                CreatedBy = "system",
            },
            new CategoryTranslation
            {
                Id = 12,
                CategoryId = 6,
                LanguageId = 2,
                Name = "Archived",
                Slug = "archived",
                Description = "Archived articles.",

                CreatedBy = "system",
            }

        });
    }
}