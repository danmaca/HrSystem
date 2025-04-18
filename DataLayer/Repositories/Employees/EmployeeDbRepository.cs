using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.Model.Employees;
using Microsoft.EntityFrameworkCore;

namespace DanM.HrSystem.DataLayer.Repositories.Employees;

public partial class EmployeeDbRepository : IEmployeeRepository
{
	public async Task<List<Employee>> GetByFilterAsync(EmployeeListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
	{
		var query = this.Data;
		if (filter.NameLike != null)
			query = query.Where(obj => obj.LastName.Contains(filter.NameLike, StringComparison.CurrentCultureIgnoreCase));
		return await query.ToListAsync(cancellationToken);
	}
}
