using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mirror_api.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }

        public string LevelName { get; set; }

        public ICollection<LevelGroup> LevelGroups { get; set; }
    }
}