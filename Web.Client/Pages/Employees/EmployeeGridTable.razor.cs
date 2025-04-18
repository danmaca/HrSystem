using DanM.Core.Web.Client.Controls;
using DanM.HrSystem.Contracts.Employees;
using Havit;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeGridTable
{
	[Inject] protected NavigationManager Navigation { get; set; }

	private List<EmployeeGridDto> gridData;
	private GridView<EmployeeGridDto> conGrid;

	private Task GridItemSelected(EmployeeGridDto item)
	{
		this.Navigation.NavigateTo(HrNavigationRoutes.Employees.EmployeeDetail + item.EmployeeId);
		return Task.CompletedTask;
	}
}
