namespace DanM.Core.Web.Client.Controls;

public partial class Button
{
	[Parameter] public string Text { get; set; }
	[Parameter] public string CssClass { get; set; } = "w-100";
	[Parameter] public EventCallback OnClick { get; set; }

	private async Task OnClickInvokedAsync()
	{
		await this.OnClick.InvokeAsync();
	}
}