using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class Student : User
    {
        public bool IsExpulsed { get; set; } = false;
        public string BankAccout { get; set; } = null;
        public bool? HasSchoolarship { get; set; } = false;
        public int GroupId { get; set; }
        public Group? Group { get; set; }
        public ICollection<Mark>? Marks { get; set; }
        public ICollection<List>? Lists { get; set; }
    }
}
