using Microsoft.Extensions.DependencyInjection;
using UOB.Repository.Repositories;

namespace UOB.Repository
{
    public static class Startup
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            // Register services
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberRecordRepository, MemberRecordRepository>();
            return services;
        }
    }
}
