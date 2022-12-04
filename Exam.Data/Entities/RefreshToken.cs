using Exam.Data.Entities.Interfaces;
using System;

namespace Exam.Data.Entities
{
    public class RefreshToken : IEntity
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; }
        public bool Invalidated { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
