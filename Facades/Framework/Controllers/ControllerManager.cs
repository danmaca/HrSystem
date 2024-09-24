using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Contracts.Employees;

namespace DanM.HrSystem.Contracts.Framework.Controllers;

public interface IControllerManager
{
	public async Task<ControllerManagerResponse> GetControllerDataAsync(ControllerManagerRequest request, CancellationToken cancellationToken = default)
	{
		var response = new ControllerManagerResponse();
		//response.ContentData = new EmployeeDetailData();
		return response;
	}
}