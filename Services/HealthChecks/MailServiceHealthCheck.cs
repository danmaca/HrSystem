﻿using DanM.HrSystem.Services.Mailing;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DanM.HrSystem.Services.HealthChecks;

public class MailServiceHealthCheck : BaseHealthCheck
{
	private readonly IMailingService _mailingService;

	public MailServiceHealthCheck(IMailingService mailingService)
	{
		_mailingService = mailingService;
	}

	protected async override Task<HealthCheckResult> CheckHealthAsync(CancellationToken cancellationToken)
	{
		await _mailingService.VerifyHealthAsync(cancellationToken);
		return HealthCheckResult.Healthy();
	}
}
