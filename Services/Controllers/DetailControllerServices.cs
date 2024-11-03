using DanM.Core.Services.Binders;
using DanM.Core.Services.Workflows;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Services.Controllers;

[Service]
public class DetailControllerServices : IDetailControllerServices
{
	public IServiceProvider ServiceProvider { get; }
	public IStandardBinders Binders { get; }
	public IUnitOfWork UnitOfWork { get; }
	public IWorkflowManager WorkflowManager { get; }

	public DetailControllerServices(IServiceProvider serviceProvider, IStandardBinders binders, IUnitOfWork unitOfWork, IWorkflowManager workflowManager)
	{
		this.ServiceProvider = serviceProvider;
		this.Binders = binders;
		this.UnitOfWork = unitOfWork;
		this.WorkflowManager = workflowManager;
	}

	public TService CreateScopeService<TService>() => this.ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<TService>();
}

public interface IDetailControllerServices : IControllerServices
{
	IServiceProvider ServiceProvider { get; }
	IStandardBinders Binders { get; }
	IUnitOfWork UnitOfWork { get; }
	IWorkflowManager WorkflowManager { get; }

	TService CreateScopeService<TService>();
}