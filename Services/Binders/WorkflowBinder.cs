using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Workflows;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Services.Binders;

[Service]
public class WorkflowBinder : ControlDataBinder, IWorkflowBinder
{
	private const string ButtonOwnerIdent = "WfTrans";

	public void Bind(BindingContextBase context, ActionButtonizerData data)
	{
		switch (context.Mode)
		{
			case BindingMode.UpdateForm:
				data.Actions.Clear();

				if (data.CurrentDialog == null)
					data.CurrentDialog = WorkflowDialog.Detail;

				if (context is DetailBindingContext detailCtx)
				{
					detailCtx.WorkflowRequest.Dialog = data.CurrentDialog;

					foreach (var transInfo in detailCtx.Workflow.ResolveAllowedTransitions(detailCtx.WorkflowRequest).Transitions)
					{
						var btnTransition = new ActionButtonDto();
						btnTransition.OwnerIdent = ButtonOwnerIdent;
						btnTransition.Key = transInfo.Transition.Key;
						btnTransition.Text = transInfo.Transition.Name;
						data.Actions.Add(btnTransition);
					}
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
	void Bind(BindingContextBase context, ActionButtonizerData data);
	Task TryRunTransition(ActionButtonizerData data, Func<string, Task> runWorkflowTransitionAction);
}