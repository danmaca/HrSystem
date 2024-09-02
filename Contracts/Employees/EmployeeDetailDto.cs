using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Primitives.Common;

namespace DanM.HrSystem.Contracts.Employees;

public class EmployeeDetailDto
{
	public int? Id { get; set; }
	public int EmployeeId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string PersonalNumber { get; set; }
	public string Email { get; set; }
	public int CreatedById { get; set; }
	public DateTime CreatedDtt { get; set; }
	public int? UpdatedById { get; set; }
	public DateTime? UpdatedDtt { get; set; }
	public EntityState State { get; set; }

	public TextControlData tbxFirstName { get; set; } = new TextControlData();
	public TextControlData tbxLastName { get; set; } = new TextControlData();
}