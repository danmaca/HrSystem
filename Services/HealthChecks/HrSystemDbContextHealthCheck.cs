using Havit.Data.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DanM.Core.Services.HealthChecks;

public class HrSystemDbContextHealthCheck : BaseHealthCheck
{
	private readonly IDbContext _dbContext;

	public HrSystemDbContextHealthCheck(IDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	protected async override Task<HealthCheckResult> CheckHealthAsync(CancellationToken cancellationToken)
	{
		return await _dbContext.Database.CanConnectAsync(cancellationToken)
			? HealthCheckResult.Healthy()
			: HealthCheckResult.Unhealthy();
	}
}
