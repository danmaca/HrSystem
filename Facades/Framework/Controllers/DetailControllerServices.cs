using DanM.HrSystem.Services.Binders;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Facades.Framework.Controllers;

[Service]
public class DetailControllerServices : IDetailControllerServices
{
	private readonly IStandardBinders _binders;
	private readonly IUnitOfWork _unitOfWork;

	public IStandardBinders Binders => _binders;
	public IUnitOfWork UnitOfWork => _unitOfWork;

	public DetailControllerServices(IStandardBinders binders, IUnitOfWork unitOfWork)
	{
		_binders = binders;
		_unitOfWork = unitOfWork;
	}
}

public interface IDetailControllerServices : IControllerServices
{
	IStandardBinders Binders { get; }
	IUnitOfWork UnitOfWork { get; }
}