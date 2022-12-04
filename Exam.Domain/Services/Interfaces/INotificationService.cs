using Exam.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface INotificationService
    {
        Task CheckUsersForExamNotification();
        Task<List<Notification>> GetByUserAsync(string userId);
    }
}
