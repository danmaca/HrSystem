using DanM.Core.Services.Binders;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Services.Controllers;

[Service]
public class ListControllerServices : ControllerServices, IListControllerServices
{
	public IStandardBinders Binders { get; }
	public IUnitOfWork UnitOfWork { get; }

	public ListControllerServices(IServiceProvider serviceProvider,
		IStandardBinders binders,
		IUnitOfWork unitOfWork)
		: base(serviceProvider)
	{
		this.Binders = binders;
		this.UnitOfWork = unitOfWork;
	}
}

public interface IListControllerServices : IControllerServices
{
	IStandardBinders Binders { get; }
	IUnitOfWork UnitOfWork { get; }
}