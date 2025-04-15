using DanM.Core.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Employees;

public class EmployeeDetailData : DetailControllerData
{
	public TextControlData tbxFirstName { get; set; } = new TextControlData();
	public TextControlData tbxLastName { get; set; } = new TextControlData();
	public TextControlData tbxPersonalNumber { get; set; } = new TextControlData();
}