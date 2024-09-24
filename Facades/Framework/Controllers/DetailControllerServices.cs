using DanM.HrSystem.Services.Framework.Binders;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Facades.Framework.Controllers;

[Service]
public class DetailControllerServices : IDetailControllerServices
{
	private readonly IStandardBinders _binders;

	public IStandardBinders Binders => _binders;

	public DetailControllerServices(IStandardBinders binders)
	{
		_binders = binders;
	}
}

public interface IDetailControllerServices : IControllerServices
{
	IStandardBinders Binders { get; }
}