using DanM.Core.Contracts.Collections;

namespace DanM.HrSystem.Contracts.Employees;

[ApiContract]
public interface IEmployeeFacade
{
	Task<ListSource<EmployeeGridDto>> GetDtosAsync(EmployeeListFilter filter, CancellationToken cancellationToken = default);
}