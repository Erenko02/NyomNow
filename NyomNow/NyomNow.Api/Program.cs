using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using Serilog;
using FluentValidation.AspNetCore;
using NyomNow.NyomNow.Api.Health;
using NyomNow.NyomNow.Api.Repositories;
using NyomNow.NyomNow.Api.Services;
using NyomNow.NyomNow.Api.Validation;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация на Serilog
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

// Зареждане на конфигурацията
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Добавяне на услуги
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderBusinessService, OrderBusinessService>();

builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

builder.Services.AddHealthChecks().AddCheck<AppHealthCheck>("app_health_check");

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
