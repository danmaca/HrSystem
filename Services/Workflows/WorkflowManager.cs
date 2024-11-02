using DanM.HrSystem.Model.Framework;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Services.Workflows;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class WorkflowManager : IWorkflowManager
{
	public event Action<WorkflowResolvingEventArgs> WorkflowResolving;

	public WorkflowBase ResolveWorkflow(WorkflowRequest request)
	{
		var args = new WorkflowResolvingEventArgs();
		args.Request = request;
		this.WorkflowResolving?.Invoke(args);
		return args.ResolvedWorkflow;
	}
}

public class WorkflowResolvingEventArgs : EventArgs
{
	public WorkflowRequest Request { get; set; }
	public WorkflowBase ResolvedWorkflow { get; set; }
}

public interface IWorkflowManager
{
	event Action<WorkflowResolvingEventArgs> WorkflowResolving;

	WorkflowBase ResolveWorkflow(WorkflowRequest request);
}