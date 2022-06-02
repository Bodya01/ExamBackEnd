using Exam.Data.Entities;

namespace Exam.Domain.Dto
{
    public class ExamNotificationDto
    {
        public User User { get; set; }
        public Subject Subject { get; set; }
    }
}
