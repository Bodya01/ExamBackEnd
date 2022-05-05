using Exam.Data.Entities.Interfaces;

namespace Exam.Data.Entities
{
    public class Mark : IEntity
    {
        public int Id { get; set; }
        public double PartialMark { get; set; }
        public double ExamMark { get; set; }
        public double TotalMark { get; set; }
        public int CourseId { get; set; }
        public string StudentId { get; set; }
        public Course Course { get; set; }
        public User Student { get; set; }
    }
}
