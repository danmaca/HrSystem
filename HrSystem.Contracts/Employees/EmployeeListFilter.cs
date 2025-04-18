using DanM.Core.Contracts.Filtering;

namespace DanM.HrSystem.Contracts.Employees;

public class EmployeeListFilter : FilterBase
{
	public string NameLike { get; set; }
}
