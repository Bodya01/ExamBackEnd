using Exam.Data.Entities.Interfaces;
using Exam.Data.Enums;
using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class List : IEntity
    {
        public int Id { get; set; }
        public ListTypes ListType { get; set; }
        public ICollection<User> Students { get; set; }
    }
}
