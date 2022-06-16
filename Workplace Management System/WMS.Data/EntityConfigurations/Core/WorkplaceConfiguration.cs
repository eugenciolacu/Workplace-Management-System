using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entities.Core;

namespace WMS.Data.EntityConfigurations.Core
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
