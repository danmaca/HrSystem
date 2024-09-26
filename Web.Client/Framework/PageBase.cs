namespace DanM.HrSystem.Web.Client.Framework;

public class PageBase : ComponentBase
{
	protected override async Task OnInitializedAsync()
	{
		await OnPageInit();
	}

	protected virtual Task OnPageInit()
	{
		return Task.CompletedTask;
	}
}
