namespace DanM.Core.Contracts.ControlDatas;

public class ActionButtonDto
{
	public string Key { get; set; }
	public string Text { get; set; }
	public event Func<Task> ActionInvoked;

	public async Task OnClickInvokedAsync()
	{
		if (this.ActionInvoked != null)
			await this.ActionInvoked();
	}
}