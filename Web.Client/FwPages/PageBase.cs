﻿using DanM.HrSystem.Web.Client.FwPages.Internals;

namespace DanM.Core.Web.Client.FwPages;

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
