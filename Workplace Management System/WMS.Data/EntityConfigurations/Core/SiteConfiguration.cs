using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entities.Core;

namespace WMS.Data.EntityConfigurations.Core
{
    public class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("Site");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.HasIndex(s => s.Name)
                .IsUnique();
            builder.HasCheckConstraint("CK_Site_Name", "Name != ''");
        }
    }
}
