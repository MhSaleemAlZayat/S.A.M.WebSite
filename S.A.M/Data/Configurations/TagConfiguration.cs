using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(64);
            builder.Property(t => t.Slug).HasMaxLength(128);
            builder.Property(t => t.CreatedBy).HasMaxLength(32);
            builder.Property(t => t.UpdatedBy).HasMaxLength(32);
            builder.Property(t => t.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
