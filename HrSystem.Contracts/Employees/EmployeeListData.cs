using DanM.Core.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Employees;

public class EmployeeListData : ListControllerData
{
	public TextControlData tbxNameLike { get; set; } = new TextControlData();
}