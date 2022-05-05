using Exam.Data.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class User : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool? HasSchoolarship { get; set; } = false;
        public bool? IsExpulsed { get; set; }
        public int? GroupId { get; set; } = null;
        public Group? Group { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<List>? Lists { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<Mark>? Marks { get; set; }
        public ICollection<Exam>? Exams { get; set; }
    }
}
