﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace DanM.HrSystem.Web.Client.Shared;

public partial class CultureSelector : ComponentBase
{
	[Inject] protected ILocalStorageService LocalStorageService { get; set; }
	[Inject] protected NavigationManager NavigationManager { get; set; }

	private async Task SetCultureAsync(string culture)
	{
		await LocalStorageService.SetItemAsStringAsync("culture", culture);
		NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
	}
}
