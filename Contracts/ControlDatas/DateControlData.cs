namespace DanM.Core.Contracts.ControlDatas;

public class DateControlData : CaptionControlData
{
	public DateTimeOffset? SelectedDate { get; set; }
	public DateOnly? SelectedDateOnly { get; set; }
}
