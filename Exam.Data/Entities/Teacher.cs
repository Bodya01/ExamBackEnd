using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class Teacher : User
    {
        public string Grade { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
