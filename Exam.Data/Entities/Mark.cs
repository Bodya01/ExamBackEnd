using Exam.Data.Entities.Interfaces;

namespace Exam.Data.Entities
{
    public class Mark : IEntity
    {
        public int Id { get; set; }
        public double PartialMark { get; set; }
        public double ExamMark { get; set; }
        public double TotalMark { get; set; }
        public bool IsConfirmed { get; set; }
        public string StudentId { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
