using Exam.Data.Context;
using Exam.Data.Entities;
using Exam.Data.Infrastructure;
using Exam.Domain.Extensions;
using Exam.Domain.Options;
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
            services.AddScoped<IRepository<RefreshToken>, Repository<RefreshToken>>();
        }
    }
}
