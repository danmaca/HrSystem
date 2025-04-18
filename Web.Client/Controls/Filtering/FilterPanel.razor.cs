namespace DanM.Core.Web.Client.Controls;

public partial class FilterPanel
{
	[Parameter] public RenderFragment FilterControls { get; set; }

	private async Task OnSearchInvokedAsync()
	{
		this.Data.IsFilteringRequested = true;
		await this.PageShare.OwnerDataPage.DoPageDataPostback();
	}
}