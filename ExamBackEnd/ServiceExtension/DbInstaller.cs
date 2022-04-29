using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Exam.Domain.Extensions;

namespace Exam.WebApi.ServiceExtension
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }
    }
}
