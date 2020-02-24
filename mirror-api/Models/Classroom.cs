namespace mirror_api.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }

        public string ClassroomTitle { get; set; }

        public string AccessCode { get; set; }

        public string ColorPicker { get; set; }

        public LevelGroup LevelGroup { get; set; }
    }
}