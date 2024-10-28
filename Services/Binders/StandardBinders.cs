using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Services.Binders;

[Service]
public class StandardBinders : IStandardBinders
{
	public ITextBinder TextBinder { get; init; }
	public IWorkflowActionsBinder WorkflowActionsBinder { get; }

	public StandardBinders(ITextBinder textBinder, IWorkflowActionsBinder actionButtonizerBinder)
	{
		this.TextBinder = textBinder;
		this.WorkflowActionsBinder = actionButtonizerBinder;
	}
}

public interface IStandardBinders
{
	ITextBinder TextBinder { get; init; }
	IWorkflowActionsBinder WorkflowActionsBinder { get; }
}