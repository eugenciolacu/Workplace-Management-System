using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entity.Core;

namespace WMS.Data.EntityConfiguration.Core
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
