using System.Collections.Generic;

namespace mirror_api.Models
{
    public class LevelGroup
    {
        public int MLevelId { get; set; }

        public int MGroupId { get; set; }

        public Level Level { get; set; }

        public Group Group { get; set; }

        public ICollection<Classroom> Classrooms { get; set; }
    }
}