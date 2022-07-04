using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entities.Core;

namespace WMS.Data.EntityConfigurations.Core
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasCheckConstraint("CK_Employee_FirstName", "FirstName != ''");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasCheckConstraint("CK_Employee_LastName", "LastName != ''");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(320);
            builder.HasCheckConstraint("CK_Employee_Email", "Email != '' and Email like '%@%'");
        }
    }
}
