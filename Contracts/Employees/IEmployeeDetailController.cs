using DanM.HrSystem.Contracts.Framework.Controllers;

namespace DanM.HrSystem.Contracts.Employees;

[ApiContract]
public interface IEmployeeDetailController : IDetailControllerBase<EmployeeDetailData>
{
	Task<Dto<int>> PersistDetailDtoAsync(EmployeeDetailData dto, CancellationToken cancellationToken = default);
}