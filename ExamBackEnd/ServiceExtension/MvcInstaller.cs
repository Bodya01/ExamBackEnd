using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.WebApi.ServiceExtension
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                // Processing all forward headers (the default is None)
                options.ForwardedHeaders = ForwardedHeaders.All;

                // Clearing known networks and proxies collections
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

            services.AddMvc();
        }
    }
}
