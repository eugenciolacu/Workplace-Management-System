using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Service.Dto.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string NormalizedUserName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string NormalizedEmail { get; set; } = String.Empty;
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; } = String.Empty;
        public string SecurityStamp { get; set; } = String.Empty;
        public string ConcurrencyStamp { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
