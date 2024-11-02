using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Workflows;
using DanM.HrSystem.Services.Workflows;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Services.Binders;

[Service]
public class WorkflowBinder : ControlDataBinder, IWorkflowBinder
{
	private const string ButtonOwnerIdent = "WfTrans";
	private readonly IWorkflowManager _workflowManager;
	public IWorkflowManager WorkflowManager => _workflowManager;

	public WorkflowBinder(IWorkflowManager workflowManager)
	{
		_workflowManager = workflowManager;
	}

	public void Bind(BindingContext context, ActionButtonizerData data)
	{
		switch (context.Mode)
		{
			case BindingMode.UpdateForm:
				data.Actions.Clear();

				if (data.CurrentDialog == null)
					data.CurrentDialog = WorkflowDialog.Detail;
				context.WorkflowRequest.Dialog = data.CurrentDialog;

				var workflow = _workflowManager.ResolveWorkflow(context.WorkflowRequest);
				foreach (var transInfo in workflow.ResolveAllowedTransitions(context.WorkflowRequest).Transitions)
				{
					var btnTransition = new ActionButtonDto();
					btnTransition.OwnerIdent = ButtonOwnerIdent;
					btnTransition.Key = transInfo.Transition.Key;
					btnTransition.Text = transInfo.Transition.Name;
					data.Actions.Add(btnTransition);
				}
				break;
		}
	}

	public async Task TryRunTransition(ActionButtonizerData data, Func<string, Task> runWorkflowTransitionAction)
	{
		var invokedAction = data.PopInvokedAction(ButtonOwnerIdent);
		if (invokedAction != null)
			await runWorkflowTransitionAction(invokedAction.Key);
	}
}

public interface IWorkflowBinder : IControlDataBinder
{
	IWorkflowManager WorkflowManager { get; }
	void Bind(BindingContext context, ActionButtonizerData data);
	Task TryRunTransition(ActionButtonizerData data, Func<string, Task> runWorkflowTransitionAction);
}