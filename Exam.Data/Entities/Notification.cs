using Exam.Data.Entities.Interfaces;
using Exam.Data.Enums;
using System;

namespace Exam.Data.Entities
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public NotificationTypes Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        public string RecieverId { get; set; }
        public User? User { get; set; }
    }
}
