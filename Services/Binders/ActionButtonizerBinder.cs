using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Workflows;
using DanM.HrSystem.Services.Workflows;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Services.Binders;

[Service]
public class WorkflowActionsBinder : ControlDataBinder, IWorkflowActionsBinder
{
	private readonly IWorkflowManager _workflowManager;

	public WorkflowActionsBinder(IWorkflowManager workflowManager)
	{
		_workflowManager = workflowManager;
	}

	public void Bind(BindingContext context, ActionButtonizerData data)
	{
		switch (context.Mode)
		{
			case BindingMode.UpdateForm:
				context.WorkflowRequest.Dialog = data.CurrentDialog ?? WorkflowDialog.Detail;

				var workflow = _workflowManager.ResolveWorkflow(context.WorkflowRequest);
				foreach (var transInfo in workflow.ResolveAllowedTransitions(context.WorkflowRequest).Transitions)
				{
					var btnTransition = new ActionButtonDto();
					btnTransition.Key = "WfTrans_" + transInfo.Transition.Key;
					btnTransition.Text = transInfo.Transition.Name;
					//btnTransition.ActionInvoked += btnTransition_ActionInvoked;
					data.Actions.Add(btnTransition);
				}
				break;
		}
	}
}

public interface IWorkflowActionsBinder : IControlDataBinder
{
	void Bind(BindingContext context, ActionButtonizerData data);
}