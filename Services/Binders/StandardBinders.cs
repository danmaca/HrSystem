using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Services.Binders;

[Service]
public class StandardBinders : IStandardBinders
{
	public ITextBinder TextBinder { get; init; }
	public IWorkflowBinder WorkflowBinder { get; }

	public StandardBinders(ITextBinder textBinder, IWorkflowBinder workflowBinder)
	{
		this.TextBinder = textBinder;
		this.WorkflowBinder = workflowBinder;
	}
}

public interface IStandardBinders
{
	ITextBinder TextBinder { get; init; }
	IWorkflowBinder WorkflowBinder { get; }
}