using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entity.Core;

namespace WMS.Data.EntityConfiguration.Core
{
    public class WorkplaceConfiguration : IEntityTypeConfiguration<Workplace>
    {
        public void Configure(EntityTypeBuilder<Workplace> builder)
        {
            builder.ToTable("Workplace");

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(w => new { w.Name, w.FloorId })
                .IsUnique();
            builder.HasCheckConstraint("CK_Workplace_Name", "Name != ''");
        }
    }
}
