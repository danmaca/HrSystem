using DanM.HrSystem.Services.Binders;
using DanM.HrSystem.Services.Workflows;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Services.Controllers;

[Service]
public class DetailControllerServices : IDetailControllerServices
{
	private readonly IStandardBinders _binders;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWorkflowManager _workflowManager;

	public IStandardBinders Binders => _binders;
	public IUnitOfWork UnitOfWork => _unitOfWork;
	public IWorkflowManager WorkflowManager => _workflowManager;

	public DetailControllerServices(IStandardBinders binders, IUnitOfWork unitOfWork, IWorkflowManager workflowManager)
	{
		_binders = binders;
		_unitOfWork = unitOfWork;
		_workflowManager = workflowManager;
	}
}

public interface IDetailControllerServices : IControllerServices
{
	IStandardBinders Binders { get; }
	IUnitOfWork UnitOfWork { get; }
	IWorkflowManager WorkflowManager { get; }
}