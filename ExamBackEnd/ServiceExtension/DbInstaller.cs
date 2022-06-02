using Exam.Data.Context;
using Exam.Data.Entities;
using Exam.Data.Infrastructure;
using Exam.Domain.Extensions;
using Exam.Domain.Services.Implementation;
using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.WebApi.ServiceExtension
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ExamContext>()
                .AddDefaultTokenProviders();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<UserManager<User>>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<IRepository<Student>, Repository<Student>>();
            services.AddScoped<IRepository<Teacher>, Repository<Teacher>>();
            services.AddScoped<IRepository<RefreshToken>, Repository<RefreshToken>>();
            services.AddScoped<IRepository<Group>, Repository<Group>>();
            services.AddScoped<IRepository<Data.Entities.Exam>, Repository<Data.Entities.Exam>>();
            services.AddScoped<IRepository<List>, Repository<List>>();
            services.AddScoped<IRepository<Subject>, Repository<Subject>>();
            services.AddScoped<IRepository<Mark>, Repository<Mark>>();
            services.AddScoped<IRepository<Notification>, Repository<Notification>>();
        }
    }
}
