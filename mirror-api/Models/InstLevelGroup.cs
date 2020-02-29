using System.Collections.Generic;

namespace mirror_api.Models
{
    public class InstLevelGroup
    {
        public Institution Institution { get; set; }
        public LevelGroup LevelGroup { get; set; }
        public string InstitutionId { get; set; }
        public ICollection<PreAuthList> PAL { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}