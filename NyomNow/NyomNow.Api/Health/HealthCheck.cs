namespace NyomNow.NyomNow.Api.Health
{
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    public class AppHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            // Тук може да добавите реални проверки (напр. за базата)
            return Task.FromResult(HealthCheckResult.Healthy("Service is running smoothly"));
        }
    }
}