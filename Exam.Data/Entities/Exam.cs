using System;

namespace Exam.Data.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int CourseId { get; set; }
        public string TeacherId { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
        public User? Teacher { get; set; }
        public Course Course { get; set; }
    }
}
