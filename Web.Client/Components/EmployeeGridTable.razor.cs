using Havit;

namespace DanM.HrSystem.Web.Client.Components;

public partial class EmployeeGridTable
{
	[Inject] protected IEmployeeFacade EmployeeFacade { get; set; }

	private List<EmployeeGridDto> data;
	private HxGrid<EmployeeGridDto> gridComponent;

	protected override async Task OnParametersSetAsync()
	{
		await gridComponent.RefreshDataAsync();
	}

	private async Task<GridDataProviderResult<EmployeeGridDto>> GetDataAsync(GridDataProviderRequest<EmployeeGridDto> request)
	{
		try
		{
			data = await EmployeeFacade.GetAllEmployeesAsync();
			return request.ApplyTo(data);
		}
		catch (OperationFailedException)
		{
			return new() { Data = null, TotalCount = 0 };
		}
	}
}
