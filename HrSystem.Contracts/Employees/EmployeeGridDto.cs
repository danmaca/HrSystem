using DanM.Core.Primitives.Common;

namespace DanM.HrSystem.Contracts.Employees;

public class EmployeeGridDto
{
	public int EmployeeId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public EntityState State { get; set; }
}