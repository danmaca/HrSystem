using Havit;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeGridTable
{
	[Inject] protected IEmployeeFacade EmployeeFacade { get; set; }
	[Inject] protected IHxMessageBoxService MessageBox { get; set; }

	private List<EmployeeGridDto> gridData;
	private HxGrid<EmployeeGridDto> conGrid;

	 private async Task<GridDataProviderResult<EmployeeGridDto>> GetDataAsync(GridDataProviderRequest<EmployeeGridDto> request)
	{
		try
		{
			gridData = await EmployeeFacade.GetAllEmployeesAsync();
			return request.ApplyTo(gridData);
		}
		catch (OperationFailedException)
		{
			return new() { Data = null, TotalCount = 0 };
		}
	}

	private async Task GridItemSelected(EmployeeGridDto item)
	{
		await MessageBox.ConfirmAsync("Potvrzení", "Opravdu si přejete všechny koncepty potvrdit?");
	}
}
