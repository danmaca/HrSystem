using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Services.Binders;

[Service]
public class StandardBinders : IStandardBinders
{
	public ITextBinder TextBinder { get; init; }

	public StandardBinders(ITextBinder textBinder)
	{
		this.TextBinder = textBinder;
	}
}

public interface IStandardBinders
{
	ITextBinder TextBinder { get; init; }
}