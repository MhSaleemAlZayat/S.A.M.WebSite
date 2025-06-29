using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(mi => mi.Id);
            builder.Property(mi => mi.MenuId).IsRequired();
            builder.Property(mi => mi.MenuItemTypeId).IsRequired();
            builder.Property(mi => mi.CssClass).HasMaxLength(64);
            builder.Property(mi => mi.CreatedBy).HasMaxLength(32);
            builder.Property(mi => mi.UpdatedBy).HasMaxLength(32);
            builder.Property(mi => mi.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(mi => mi.IsDeleted).HasDefaultValueSql("0");
            builder.Property(mi => mi.Active).HasDefaultValueSql("1");

            builder.HasOne<Menu>()
                   .WithMany()
                   .HasForeignKey(mi => mi.MenuId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<MenuItem>()
                   .WithMany()
                   .HasForeignKey(mi => mi.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
