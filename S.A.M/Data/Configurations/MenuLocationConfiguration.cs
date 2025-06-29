using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations;
public class MenuLocationConfiguration : IEntityTypeConfiguration<MenuLocation>
{
    public void Configure(EntityTypeBuilder<MenuLocation> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasConversion<byte>().IsRequired();
        builder.Property(s => s.Name).HasConversion<string>().IsRequired().HasMaxLength(64);
        builder.Property(s => s.Description).HasMaxLength(256);


        builder.HasOne(s => s.Menu)
            .WithOne(m => m.MenuLocation)
            .HasForeignKey<Menu>(m => m.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public static class MenuLocationSeed
{
    public static void SeedMenuLocationValues(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuLocation>().HasData(new MenuLocation[]
        {
            new MenuLocation
            {
                Id = MenuLocation.MenuLocationEnum.MainMenu,
                Name = MenuLocation.MenuLocationEnum.MainMenu,
                Description = "القائمة الرئيسية: القائمة الرئيسية للموقع."
            },
            new MenuLocation
            {
                Id = MenuLocation.MenuLocationEnum.FooterMenu,
                Name = MenuLocation.MenuLocationEnum.FooterMenu,
                Description = "القائمة السفلية: قائمة الروابط في أسفل الصفحة."
            },
            new MenuLocation
            {
                Id = MenuLocation.MenuLocationEnum.SidebarMenu,
                Name = MenuLocation.MenuLocationEnum.SidebarMenu,
                Description = "القائمة الجانبية: قائمة تظهر في الجانب الأيسر أو الأيمن من الصفحة."
            },
            new MenuLocation
            {
                Id = MenuLocation.MenuLocationEnum.HeaderMenu,
                Name = MenuLocation.MenuLocationEnum.HeaderMenu,
                Description = "القائمة العلوية: قائمة تظهر في أعلى الصفحة."
            },
            new MenuLocation
            {
                Id = MenuLocation.MenuLocationEnum.CustomMenu,
                Name = MenuLocation.MenuLocationEnum.CustomMenu,
                Description = "قائمة مخصصة: قوائم يمكن تخصيصها حسب الحاجة."
            }
        });
    }
}
