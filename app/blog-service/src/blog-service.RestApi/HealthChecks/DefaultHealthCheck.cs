using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace blog_service.RestApi.HealthChecks
{
    public sealed class DefaultHealthCheck : IHealthCheck
    {
        public DefaultHealthCheck(IConfiguration config, ILogger<DefaultHealthCheck> log)
        {
            log.LogWarning(config.GetSection("TEST")["Env"]);
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy("Service is Running"));
        }
    }
}
