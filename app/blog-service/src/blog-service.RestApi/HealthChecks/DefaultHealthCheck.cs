using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace blog_service.RestApi.HealthChecks
{
    public sealed class DefaultHealthCheck : IHealthCheck
    {
        public DefaultHealthCheck(IConfiguration config, ILogger<DefaultHealthCheck> log)
        {
            log.LogWarning(config.GetSection("TestConfigSection")["Test"]);
            log.LogWarning(config.GetSection("TEST")["Env"]);
            log.LogWarning(config.GetConnectionString("MySqlDb"));
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy("Service is Running"));
        }
    }
}
