using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Data.Entity.Auth;

namespace WMS.Data.EntityConfiguration.Auth
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            //builder.Ignore(x => x.NormalizedUserName);
            //builder.Ignore(x => x.Email);
            //builder.Ignore(x => x.NormalizedEmail);
            //builder.Ignore(x => x.EmailConfirmed);
            //builder.Ignore(x => x.PhoneNumber);
            //builder.Ignore(x => x.PhoneNumberConfirmed);
            //builder.Ignore(x => x.TwoFactorEnabled);
            //builder.Ignore(x => x.LockoutEnd);
            //builder.Ignore(x => x.LockoutEnabled);
            //builder.Ignore(x => x.AccessFailedCount);
            //builder.Ignore(x => x.SecurityStamp);
            //builder.Ignore(x => x.ConcurrencyStamp);
        }
    }
}
