using DanM.Core.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Agreements;

public class AgreementDetailData : DetailControllerData
{
	public TextControlData tbxName { get; set; } = new TextControlData();
	public DateControlData dtpValidFrom { get; set; } = new DateControlData();
	public DateControlData dtpValidTo { get; set; } = new DateControlData();
}