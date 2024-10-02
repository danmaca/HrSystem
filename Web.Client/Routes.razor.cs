using DanM.Core.Contracts.Infrastructure;
using DanM.HrSystem.Resources;
using Microsoft.AspNetCore.Components;

namespace DanM.HrSystem.Web.Client;

public partial class Routes
{
	[Inject] protected IFluentValidationDefaultMessagesLocalizer ValidationMessagesLocalizer { get; set; }

	protected override void OnInitialized()
	{
		// we cannot use IStringLocalizer in application startup class (locks the culture to the invariant one)
		FluentValidationLocalizationHelper.RegisterDefaultValidationMessages(this.ValidationMessagesLocalizer);
	}
}