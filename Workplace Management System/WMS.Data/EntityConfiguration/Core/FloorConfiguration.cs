using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entity.Core;

namespace WMS.Data.EntityConfiguration.Core
{
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floor");

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasIndex(f => new { f.Name, f.SiteId })
                .IsUnique();
            builder.HasCheckConstraint("CK_Floor_Name", "Name != ''");
        }
    }
}
