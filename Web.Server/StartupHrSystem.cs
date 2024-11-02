using DanM.Core.Services.Workflows;

namespace DanM.HrSystem.Web.Server;

public class StartupHrSystem
{
	private CodetableWorkflow _codetableWorkflow;

	public void SetupHrSystem(WebApplication app)
	{
		var wfManager = app.Services.GetRequiredService<IWorkflowManager>();
		wfManager.WorkflowResolving += args =>
		{
			if (_codetableWorkflow == null)
				_codetableWorkflow = new CodetableWorkflow();
			args.ResolvedWorkflow = _codetableWorkflow;
		};
	}
}
