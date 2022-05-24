using Exam.Data.Entities.Interfaces;
using Exam.Data.Enums;
using System;
using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class List : IEntity
    {
        public int Id { get; set; }
        public ListTypes ListType { get; set; }
        public string GroupName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
