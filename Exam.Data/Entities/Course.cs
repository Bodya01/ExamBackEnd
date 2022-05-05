using Exam.Data.Entities.Interfaces;
using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Mark> Marks { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
