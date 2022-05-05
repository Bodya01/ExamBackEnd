using Exam.Data.Entities.Interfaces;

namespace Exam.Data.Entities
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string TeacherId { get; set; }
        public int CourseId { get; set; }
        public User? Teacher { get; set; }
        public Course? Course { get; set; }
    }
}
