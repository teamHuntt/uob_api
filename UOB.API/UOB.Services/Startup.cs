using Microsoft.Extensions.DependencyInjection;
using UOB.Repository.Repositories;
using UOB.Services.Books;
using UOB.Services.Member;
using UOB.Services.MembersRecord;

namespace UOB.Services
{
    public static class Startup
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            // Register services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMembersRecordService, MembersRecordService>();
            return services;
        }
    }
}
