namespace NyomNow.NyomNow.Api
{
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Hosting;
    using NyomNow.Api.Business;
    using NyomNow.Api.Health;
    using NyomNow.Api.Repositories;
    using NyomNow.Api.Services;
    using NyomNow.Api.Validation;
    using Serilog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Добавяме контролери + FluentValidation
            services.AddControllers().AddFluentValidation();

            // Регистрираме FluentValidators
            services.AddValidatorsFromAssemblyContaining<OrderValidator>();
            services.AddValidatorsFromAssemblyContaining<UserValidator>();

            // Регистрираме MongoDB репозиториите
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            // Регистрираме сервизите
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IOrderService, OrderService>();

            // Регистрираме бизнес логиката
            services.AddSingleton<IBusinessService, BusinessService>();

            // HealthChecks
            services.AddHealthChecks()
                    .AddCheck<AppHealthCheck>("app_health_check");

            // Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            services.AddLogging(builder => builder.AddSerilog());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}