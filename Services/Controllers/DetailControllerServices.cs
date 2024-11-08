﻿using DanM.Core.Services.Binders;
using DanM.Core.Services.Workflows;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Services.Controllers;

[Service]
public class DetailControllerServices : ControllerServices, IDetailControllerServices
{
	public IStandardBinders Binders { get; }
	public IUnitOfWork UnitOfWork { get; }
	public IWorkflowManager WorkflowManager { get; }

	public DetailControllerServices(IServiceProvider serviceProvider,
		IStandardBinders binders,
		IUnitOfWork unitOfWork,
		IWorkflowManager workflowManager)
		: base(serviceProvider)
	{
		this.Binders = binders;
		this.UnitOfWork = unitOfWork;
		this.WorkflowManager = workflowManager;
	}
}

public interface IDetailControllerServices : IControllerServices
{
	IStandardBinders Binders { get; }
	IUnitOfWork UnitOfWork { get; }
	IWorkflowManager WorkflowManager { get; }
}