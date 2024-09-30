using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.DataLayer.Repositories.Employees;
using DanM.HrSystem.Facades.Framework.Controllers;
using DanM.HrSystem.Facades.ModelDescriptors;
using DanM.HrSystem.Model.Employees;
using DanM.HrSystem.Services.Binders;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Employees;

[Service]
[Authorize]
public class EmployeeDetailController : DetailControllerBase<Employee, EmployeeDetailData>, IEmployeeDetailController
{
	private readonly IDetailControllerServices _services;
	private readonly IEmployeeDescriptor _employeeDescriptor;
	private readonly IEmployeeRepository _employeeRepository;

	public EmployeeDetailController(
		IDetailControllerServices services,
		IEmployeeDescriptor employeeDescriptor,
		IEmployeeRepository employeeRepository)
		: base(services)
	{
		_services = services;
		_employeeDescriptor = employeeDescriptor;
		_employeeRepository = employeeRepository;
	}

	protected override async Task<Employee> OnLoadEntityAsync()
	{
		return await _employeeRepository.GetObjectAsync(this.Data.Setup.EntityId.Value);
	}

	protected override void OnBindingProperties(BindingContext ctx)
	{
		base.OnBindingProperties(ctx);

		this.Binders.TextBinder.Bind(ctx, this.Data.tbxFirstName, _employeeDescriptor.FirstNameProp);
		this.Binders.TextBinder.Bind(ctx, this.Data.tbxLastName, _employeeDescriptor.LastNameProp);
	}
}

public interface IEmployeeDetailController : IDetailControllerBase<EmployeeDetailData>
{
}