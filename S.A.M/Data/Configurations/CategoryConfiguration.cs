using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.CreatedBy).HasMaxLength(36); ;
        builder.Property(c => c.UpdatedBy).HasMaxLength(36); ;
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(c => c.IsDeleted).HasDefaultValueSql("0");
        builder.Property(c => c.Active).HasDefaultValueSql("1");

        builder.HasOne(c => c.Parent)
            .WithMany()
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        //builder.HasMany<CategoryTranslation>()
        //    .WithOne(ct => ct.Category)
        //    .HasForeignKey(ct => ct.CategoryId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}

public static class CategorySeed
{
    public static void SeedCategoryValues(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category
            {
                Id = 1,
                CreatedBy = "system",

            },
            new Category
            {
                Id = 2,
                CreatedBy = "system",

            },
            new Category
            {
                Id = 3,
                CreatedBy = "system",

            },
            new Category
            {
                Id = 4,
                CreatedBy = "system",

            },
            new Category
            {
                Id = 5,
                CreatedBy = "system",

            },
            new Category
            {
                Id = 6,
                CreatedBy = "system",

            }

        });

}
