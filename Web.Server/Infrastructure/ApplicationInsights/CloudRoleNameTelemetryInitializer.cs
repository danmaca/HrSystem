using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace DanM.HrSystem.Web.Server.Infrastructure.ApplicationInsights;

public class CloudRoleNameTelemetryInitializer : ITelemetryInitializer
{
	public void Initialize(ITelemetry telemetry)
	{
		telemetry.Context.Cloud.RoleName = "Web.Server";
	}
}
