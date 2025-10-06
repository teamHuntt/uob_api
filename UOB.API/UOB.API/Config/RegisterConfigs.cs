namespace UOB.API.Middlewares
{
    public static class RegisterConfigs
    {
        //Middleware to handle exceptions globally
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
        //CORS policy to allow all origins, methods, and headers
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            return services;
        }
    }
}
