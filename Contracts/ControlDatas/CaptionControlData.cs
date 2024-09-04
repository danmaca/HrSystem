namespace DanM.HrSystem.Contracts.ControlDatas;

public class CaptionControlData : ControlData, ICaptionControlData
{
	public string CaptionText { get; set; }
}

public interface ICaptionControlData : IControlData
{
	string CaptionText { get; set; }
}