using DanM.Core.Services.Workflows;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Services.Binders;

[Service]
public class StandardBinders : IStandardBinders
{
	public ITextBinder TextBinder { get; }
	public IWorkflowBinder WorkflowBinder { get; }

	public StandardBinders(ITextBinder textBinder, IWorkflowBinder workflowBinder)
	{
		this.TextBinder = textBinder;
		this.WorkflowBinder = workflowBinder;
	}
}

public interface IStandardBinders
{
	ITextBinder TextBinder { get; }
	IWorkflowBinder WorkflowBinder { get; }
}