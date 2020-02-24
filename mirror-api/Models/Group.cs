using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mirror_api.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        public string GroupName { get; set; }
        
        public ICollection<LevelGroup> LevelGroups { get; set; }
    }
}