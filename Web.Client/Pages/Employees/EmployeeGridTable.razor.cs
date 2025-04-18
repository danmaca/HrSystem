using DanM.Core.Web.Client.Controls;
using DanM.HrSystem.Contracts.Employees;
using Havit;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeGridTable
{
	[Inject] protected IEmployeeFacade EmployeeFacade { get; set; }
	[Inject] protected NavigationManager Navigation { get; set; }

	private List<EmployeeGridDto> gridData;
	private GridView<EmployeeGridDto> conGrid;

	private async Task<GridDataProviderResult<EmployeeGridDto>> GetGridDataAsync(GridDataProviderRequest<EmployeeGridDto> request)
	{
		try
		{
			var filter = (EmployeeListFilter)this.Data.DataFilter;
			gridData = await EmployeeFacade.GetDtosAsync(filter);
			return new GridDataProviderResult<EmployeeGridDto>()
			{
				Data = gridData,
				TotalCount = 10
			};
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
