using Exam.Data.Entities.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string TeacherId { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Mark> Marks { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
