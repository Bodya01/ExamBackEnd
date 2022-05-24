using Exam.Data.Entities.Interfaces;
using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
