using DanM.HrSystem.Web.Client.Controls.Framework;
using DanM.HrSystem.Web.Client.Infrastructure.Rendering;

namespace DanM.HrSystem.Web.Client.Framework;

public class PageBase : ComponentBase
{
	public PageShareObject CurrentPageShare { get; }

	public PageBase()
	{
		this.CurrentPageShare = new PageShareObject
		{
			OwnerPage = this,
		};
	}

	protected override async Task OnInitializedAsync()
	{
		await OnPageInit();
	}

	protected virtual Task OnPageInit()
	{
		return Task.CompletedTask;
	}
}
