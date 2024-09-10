using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Services.Framework.Binders;

[Service]
public class StandardBinders : IStandardBinders
{
	public ITextBinder TextBinder { get; init; }

	public StandardBinders(ITextBinder textBinder)
	{
		TextBinder = textBinder;
	}
}

public interface IStandardBinders
{
	ITextBinder TextBinder { get; init; }
}