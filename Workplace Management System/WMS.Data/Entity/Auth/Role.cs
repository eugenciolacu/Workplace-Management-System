using Microsoft.AspNetCore.Identity;

namespace WMS.Data.Entity.Auth
{
    public class Role : IdentityRole<Guid>
    {
        public Role(string name) : base(name)
        {
        }
    }
}
