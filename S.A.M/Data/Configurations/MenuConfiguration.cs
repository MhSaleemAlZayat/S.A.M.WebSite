using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(128);
            builder.Property(m => m.Location).HasMaxLength(64);
            builder.Property(m => m.CreatedBy).HasMaxLength(32);
            builder.Property(m => m.UpdatedBy).HasMaxLength(32);
            builder.Property(m => m.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
