using DanM.HrSystem.Contracts.Employees;
using Havit;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeGridTable
{
	[Inject] protected IEmployeeFacade EmployeeFacade { get; set; }
	[Inject] protected IHxMessageBoxService MessageBox { get; set; }
	[Inject] protected NavigationManager Navigation { get; set; }

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

	private Task GridItemSelected(EmployeeGridDto item)
	{
		this.Navigation.NavigateTo(HrNavigationRoutes.Employees.EmployeeDetail + item.EmployeeId);
		return Task.CompletedTask;
	}
}
