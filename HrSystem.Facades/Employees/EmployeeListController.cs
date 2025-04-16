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

	public EmployeeListController(
		IListControllerServices services,
		IEmployeeListFilterDescriptor filterDesc)
		: base(services)
	{
		_filterDesc = filterDesc;
	}

	protected override void OnBindingProperties(ListBindingContext ctx)
	{
		base.OnBindingProperties(ctx);

		this.Binders.TextBinder.Bind(ctx, Data.tbxNameLike, _filterDesc.NameLike);
	}

	protected override void OnFillMainGrid()
	{
		//Data.lstMainGrid;
	}
}

public interface IEmployeeListController : IEntityListControllerBase<Employee, EmployeeListFilter, EmployeeListData>
{
}