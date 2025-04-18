using DanM.Core.Contracts.Collections;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.Model.Employees;

namespace DanM.HrSystem.DataLayer.Repositories.Employees;

public partial interface IEmployeeRepository
{
	Task<ListSource<Employee>> GetByFilterAsync(EmployeeListFilter filter, CancellationToken cancellationToken = default);
}
