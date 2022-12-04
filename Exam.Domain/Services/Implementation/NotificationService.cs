using Exam.Data.Entities;
using Exam.Data.Enums;
using Exam.Data.Infrastructure;
using Exam.Domain.Hubs;
using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly IExamService examService;
        private readonly IHubContext<SignalRHub> notificationHub;
        private readonly IRepository<Notification> notificationRepository;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IRepository<Data.Entities.Exam> examRepository;

        public NotificationService(
            IRepository<Notification> notificationRepository,
            IHubContext<SignalRHub> notificationHub,
            IExamService examService,
            IRepository<Data.Entities.Exam> examRepository
            )
        {
            this.notificationRepository = notificationRepository;
            this.notificationHub = notificationHub;
            this.examService = examService;
            this.examRepository = examRepository;
        }

        public Task<List<Notification>> GetByUserAsync(string userId) =>
            notificationRepository
                .Query()
                .Where(n => n.RecieverId == userId)
                .ToListAsync();

        public async Task CheckUsersForExamNotification()
        {
            var exams = await examRepository
                .Query()
                .Include(e => e.Group)
                    .ThenInclude(g => g.Students)
                .Include(e => e.Subject)
                    .ThenInclude(e => e.Teachers)
                .ToListAsync();

            var tomorrowExams = exams.Where(e => IsExamTomorrow(e.ExamDate));

            if (tomorrowExams is not null)
            {
                foreach (var exam in tomorrowExams)
                {
                    var students = exam.Group.Students.ToList();
                    var teachers = exam.Subject.Teachers.ToList();

                    foreach (var student in students)
                    {
                        var notification = new Notification
                        {
                            Type = NotificationTypes.ExamReminder,
                            RecieverId = student.Id,
                            CreatedAt = DateTime.Now,
                            IsRead = false,
                            JsonData = JsonSerializer.Serialize(new
                            {
                                subject = exam.Subject.Name,
                                time = exam.ExamDate
                            }),
                        };
                        await AddNotificationAsync(notification);
                    }

                    foreach (var teacher in teachers)
                    {
                        var notification = new Notification
                        {
                            Type = NotificationTypes.ExamReminder,
                            RecieverId = teacher.Id,
                            CreatedAt = DateTime.Now,
                            IsRead = false,
                            JsonData = JsonSerializer.Serialize(new
                            {
                                subject = exam.Subject.Name,
                                time = exam.ExamDate
                            }),
                        };
                        await AddNotificationAsync(notification);
                    }
                }
            }
            else
            {
                var a = 1;
            }
                        
        }

        public async Task<Notification> AddNotificationAsync(Notification notification)
        {
            await notificationRepository.AddAsync(notification);
            await notificationRepository.SaveChangesAsync();

            await NotifyClient(notification);

            return notification;
        }

        private bool IsExamTomorrow(DateTime examDate)
        {
            var dateDiff = (DateTime.Today - examDate.Date).TotalDays;
            if (dateDiff == -1)
            {
                return true;
            }

            return false;
        }

        private async Task NotifyClient(Notification notification)
        {
            await notificationHub.Clients.All.SendAsync("sendToReact",  notification);
        }
    }
}
