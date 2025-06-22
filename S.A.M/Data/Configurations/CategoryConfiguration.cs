using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(128);
            builder.Property(c => c.Slug).HasMaxLength(256);
            builder.Property(c => c.Description).HasMaxLength(512);
            builder.Property(c => c.CreatedBy).HasMaxLength(32);
            builder.Property(c => c.UpdatedBy).HasMaxLength(32);
            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(c => c.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
