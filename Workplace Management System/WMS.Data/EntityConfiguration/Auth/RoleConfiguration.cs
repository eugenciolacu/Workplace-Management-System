using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entity.Auth;

namespace WMS.Data.EntityConfiguration.Auth
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            //builder.Ignore(x => x.NormalizedName);
            //builder.Ignore(x => x.ConcurrencyStamp);
        }
    }
}
