using System.Collections.Generic;

namespace mirror_api.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string PasswordHash { get; set; }
        public bool MobileConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }

        public ICollection<UserRole> Roles { get; set; }
    }
}