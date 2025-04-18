using DanM.Core.Contracts.Collections;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.DataLayer.Repositories.Common;
using DanM.HrSystem.Model.Employees;

namespace DanM.HrSystem.DataLayer.Repositories.Employees;

public partial class EmployeeDbRepository : IEmployeeRepository
{
	public async Task<ListSource<Employee>> GetByFilterAsync(EmployeeListFilter filter, CancellationToken cancellationToken = default)
	{
		var query = this.GetData(filter);
		if (filter.NameLike != null)
			query = query.Where(obj => obj.LastName.IndexOf(filter.NameLike) >= 0);
		return await query.ToListSourceAsync(filter, cancellationToken);
	}
}
