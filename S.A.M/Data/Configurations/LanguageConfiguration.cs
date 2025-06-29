using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Code).IsRequired().HasMaxLength(8);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(64);
        builder.Property(c => c.Culture).IsRequired().HasMaxLength(8);
        builder.Property(c => c.Default).IsRequired().HasDefaultValueSql("0");
        builder.Property(c => c.SortOrder).IsRequired().HasDefaultValueSql("1");
        builder.Property(c => c.CreatedBy).IsRequired().HasMaxLength(32);
        builder.Property(c => c.UpdatedBy).HasMaxLength(32);
        builder.Property(c => c.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        builder.Property(c => c.IsDeleted).HasDefaultValueSql("0");
        builder.Property(c => c.Active).HasDefaultValueSql("1");

    }
}

public static class LanguageSeed
{
    public static void SeedLanguageValues(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(new Language[]
        {
            new Language
            {
                Id = 1,
                Code = "ar",
                Name = "العربية",
                Culture = "ar-SA",
                Default = true,
                SortOrder = 1,
                CreatedBy = "system",
            },
            new Language
            {
                Id = 2,
                Code = "en",
                Name = "English",
                Culture = "en-US",
                Default = false,
                SortOrder = 2,
                CreatedBy = "system",
            }
        });
    }
}
