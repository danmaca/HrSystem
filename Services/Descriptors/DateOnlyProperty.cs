namespace DanM.Core.Services.Descriptors;

public class DateOnlyProperty : DateTimePropertyBase<DateOnly?>
{
	public DateOnlyProperty(Func<string> captionText)
		: base(captionText)
	{
	}
}
