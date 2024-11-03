using DanM.Core.Facades.ModelDescriptors;
using DanM.Core.Services.Binders;
using DanM.Core.Services.Controllers;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.DataLayer.Repositories.Employees;
using DanM.HrSystem.Model.Employees;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Employees;

[Service]
[Authorize]
public class EmployeeDetailController : EntityDetailControllerBase<Employee, IEmployeeRepository, EmployeeDetailData>, IEmployeeDetailController
{
	private readonly IEmployeeDescriptor _employeeDescriptor;

	public EmployeeDetailController(
		IDetailControllerServices services,
		IEmployeeDescriptor employeeDescriptor)
		: base(services)
	{
		_employeeDescriptor = employeeDescriptor;
	}

	protected override void OnBindingProperties(BindingContext ctx)
	{
		base.OnBindingProperties(ctx);

		this.Binders.TextBinder.Bind(ctx, this.Data.tbxFirstName, _employeeDescriptor.FirstName);
		this.Binders.TextBinder.Bind(ctx, this.Data.tbxLastName, _employeeDescriptor.LastName);
	}
}

public interface IEmployeeDetailController : IDetailControllerBase<EmployeeDetailData>
{
}