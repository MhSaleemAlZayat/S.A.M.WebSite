using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;
public class MenuItemTypeConfiguration : IEntityTypeConfiguration<MenuItemType>
{
    public void Configure(EntityTypeBuilder<MenuItemType> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasConversion<byte>().IsRequired();
        builder.Property(s => s.Name).HasConversion<string>().IsRequired().HasMaxLength(64);
        builder.Property(s => s.Description).HasMaxLength(256);


        builder.HasMany(s => s.MenuItems)
            .WithOne(mi => mi.MenuItemType)
            .HasForeignKey(mi => mi.MenuItemTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public static class MenuItemTypeSeed
{
    public static void SeedMenuItemTypeValues(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItemType>().HasData(new MenuItemType[]
        {
            new MenuItemType
            {
                Id = MenuItemType.MenuItemTypeEnum.Link,
                Name = MenuItemType.MenuItemTypeEnum.Link,
                Description = "رابط: عنصر قائمة بسيط يوجه إلى عنوان URL."
            },
            new MenuItemType
            {
                Id = MenuItemType.MenuItemTypeEnum.Artile,
                Name = MenuItemType.MenuItemTypeEnum.Artile,
                Description = "مقالة: عنصر قائمة يوجه إلى مقالة."
            },
            new MenuItemType
            {
                Id = MenuItemType.MenuItemTypeEnum.Page,
                Name = MenuItemType.MenuItemTypeEnum.Page,
                Description = "صحفة: عنصر قائمة يوجه إلى صفحة."
            },
            new MenuItemType
            {
                Id = MenuItemType.MenuItemTypeEnum.Cateogry,
                Name = MenuItemType.MenuItemTypeEnum.Cateogry,
                Description = "تصنيف: عنصر مقالة يوجة إلى تصنيف."
            }
        });
    }
}
