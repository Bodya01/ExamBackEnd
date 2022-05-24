using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exam.WebApi.ServiceExtension
{
    public static class RecurringJobExtension
    {
        public static void AddReccuringJobs(this IServiceProvider serviceProvider, IRecurringJobManager recurringJobManager)
        {

        }
    }
}
