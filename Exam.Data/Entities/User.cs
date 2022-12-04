using Exam.Data.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Exam.Data.Entities
{
    public class User : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
