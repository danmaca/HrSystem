using System.Runtime.Serialization;
using DanM.Core.Contracts.Workflows;

namespace DanM.Core.Contracts.ControlDatas;

public class ActionButtonizerData : ControlData
{
	public string CurrentDialogId { get; set; }
	[IgnoreDataMember]
	public WorkflowDialog CurrentDialog
	{
		get => WorkflowDialog.ByName(this.CurrentDialogId);
		set => this.CurrentDialogId = value.Name;
	}

	public List<ActionButtonDto> Actions { get; set; } = new List<ActionButtonDto>();
	public string InvokedActionKey { get; set; }

	public ActionButtonDto PopInvokedAction(string ownerIdent)
	{
		ActionButtonDto invokedAction = null;
		if (this.InvokedActionKey != null)
			invokedAction = this.Actions.FirstOrDefault(obj => obj.UniqueKey == this.InvokedActionKey && obj.OwnerIdent == ownerIdent);

		if (invokedAction != null)
		{
			this.InvokedActionKey = null;
		}
		return invokedAction;
	}
}