using DanM.Core.Contracts.Filtering;

namespace DanM.HrSystem.Contracts.Employees;

public class EmployeeListFilter : IFilterBase
{
	public string NameLike { get; set; }
}
