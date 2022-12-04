using Exam.Domain.Services.Interfaces;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exam.WebApi.ServiceExtension
{
    public static class RecurringJobExtension
    {
        public static void AddReccuringJobs(this IServiceProvider serviceProvider, IRecurringJobManager recurringJobManager)
        {
            recurringJobManager.AddOrUpdate(
                "SendUsersExamNotifications",
                () => serviceProvider.GetService<INotificationService>()!.CheckUsersForExamNotification(),
                Cron.Daily(),
                TimeZoneInfo.Utc);
        }
    }
}
