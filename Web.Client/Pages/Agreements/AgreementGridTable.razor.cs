using DanM.HrSystem.Contracts.Agreements;
using Havit;

namespace DanM.HrSystem.Web.Client.Pages.Agreements;

public partial class AgreementGridTable
{
	[Inject] protected IAgreementFacade AgreementFacade { get; set; }
	[Inject] protected IHxMessageBoxService MessageBox { get; set; }
	[Inject] protected NavigationManager Navigation { get; set; }

	private List<AgreementGridDto> gridData;
	private HxGrid<AgreementGridDto> conGrid;

	private async Task<GridDataProviderResult<AgreementGridDto>> GetGridDataAsync(GridDataProviderRequest<AgreementGridDto> request)
	{
		try
		{
			gridData = await AgreementFacade.GetItemsAsync();
			return request.ApplyTo(gridData);
		}
		catch (OperationFailedException)
		{
			return new() { Data = null, TotalCount = 0 };
		}
	}

	private Task GridItemSelected(AgreementGridDto item)
	{
		this.Navigation.NavigateTo(HrNavigationRoutes.Agreements.AgreementDetail + item.AgreementId);
		return Task.CompletedTask;
	}
}
