namespace DanM.HrSystem.Web.Client.Pages.Framework;

public class PageBase : ComponentBase
{
	protected override async Task OnInitializedAsync()
	{
		await this.OnPageInit();
	}

	protected virtual Task OnPageInit()
	{
		return Task.CompletedTask;
	}
}
