using Exam.Domain.Options;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace Exam.WebApi.ServiceExtension
{
    public class MvcInstaller : IInstaller
    {
        private readonly JwtSettings jwtSettings = new JwtSettings();
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR()
                .AddNewtonsoftJsonProtocol( options => options.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddHangfireServer();

            services.AddMvc();

            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);
            services.AddSingleton(GetValidationParameters());

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                // Processing all forward headers (the default is None)
                options.ForwardedHeaders = ForwardedHeaders.All;

                // Clearing known networks and proxies collections
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = GetValidationParameters();
                });
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = false,
            };
        }
    }
}
