using System;

namespace Exam.Data.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
