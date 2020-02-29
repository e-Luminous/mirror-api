using System.Collections.Generic;

namespace mirror_api.Models
{
    public class Role
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string NormalizedName { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}