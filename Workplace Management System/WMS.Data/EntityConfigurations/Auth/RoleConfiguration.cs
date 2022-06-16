using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entities;
using WMS.Data.Entities.Auth;

namespace WMS.Data.EntityConfigurations.Auth
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            //builder.Ignore(x => x.NormalizedName);
            //builder.Ignore(x => x.ConcurrencyStamp);

            builder.HasData(
                new Role (UserRoles.Admin) { Id = Guid.NewGuid(), Name = UserRoles.Admin, NormalizedName = UserRoles.Admin.ToUpper() },
                new Role (UserRoles.User) { Id = Guid.NewGuid(), Name = UserRoles.User, NormalizedName = UserRoles.User.ToUpper() }
            );
        }
    }
}
