using DanM.Core.Facades.ModelDescriptors.Employees;
using DanM.Core.Services.Binders;
using DanM.Core.Services.Controllers;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.Model.Employees;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Employees;

[Service]
[Authorize]
public class EmployeeListController : EntityListControllerBase<Employee, EmployeeListFilter, EmployeeListData>, IEmployeeListController
{
	private readonly IEmployeeListFilterDescriptor _filterDesc;
	private readonly IEmployeeFacade _employeeFacade;

	public EmployeeListController(
		IListControllerServices services,
		IEmployeeListFilterDescriptor filterDesc,
		IEmployeeFacade employeeFacade)
		: base(services)
	{
		_filterDesc = filterDesc;
		_employeeFacade = employeeFacade;
	}

	protected override void OnBindingProperties(ListBindingContext ctx)
	{
		base.OnBindingProperties(ctx);

		this.Binders.TextBinder.Bind(ctx, Data.tbxNameLike, _filterDesc.NameLike);
	}

	protected override void OnFillMainGrid()
	{
		Data.lstMainGrid.FillData(this.Filter, typeof(IEmployeeFacade));
	}
}

public interface IEmployeeListController : IEntityListControllerBase<Employee, EmployeeListFilter, EmployeeListData>
{
}