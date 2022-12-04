using Exam.Data.Entities.Interfaces;
using System;

namespace Exam.Data.Entities
{
    public class Exam : IEntity
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
    }
}
