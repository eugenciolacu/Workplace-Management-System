using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entity.Core;

namespace WMS.Data.EntityConfiguration.Core
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.Property(r => r.StartTimestamp)
                .IsRequired();
            builder.HasCheckConstraint("CK_Reservation_StartTimestamp", "StartTimestamp >= SYSDATETIME()");
            builder.HasCheckConstraint("CK_Reservation_EndTimestamp", "StartTimestamp < EndTimestamp");
        }
    }
}
