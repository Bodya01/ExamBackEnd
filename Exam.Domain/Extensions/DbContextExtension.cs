using Exam.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Domain.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ExamConnection");

            services.AddDbContext<ExamContext>(options =>
                  options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Exam.Data")));
        }
    }
}
