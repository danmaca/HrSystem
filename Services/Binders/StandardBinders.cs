using DanM.Core.Services.Workflows;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Services.Binders;

[Service]
public class StandardBinders : IStandardBinders
{
	public ITextBinder TextBinder { get; }
	public IWorkflowBinder WorkflowBinder { get; }
	public IDateOnlyBinder DateOnlyBinder { get; }

	public StandardBinders(ITextBinder textBinder,
		IWorkflowBinder workflowBinder,
		IDateOnlyBinder dateOnlyBinder)
	{
		this.TextBinder = textBinder;
		this.WorkflowBinder = workflowBinder;
		this.DateOnlyBinder = dateOnlyBinder;
	}
}

public interface IStandardBinders
{
	ITextBinder TextBinder { get; }
	IWorkflowBinder WorkflowBinder { get; }
	IDateOnlyBinder DateOnlyBinder { get; }
}