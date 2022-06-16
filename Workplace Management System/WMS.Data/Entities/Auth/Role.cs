using Microsoft.AspNetCore.Identity;

namespace WMS.Data.Entities.Auth
{
    public class Role : IdentityRole<Guid>
    {
        public Role(string name) : base(name)
        {
        }
    }
}
