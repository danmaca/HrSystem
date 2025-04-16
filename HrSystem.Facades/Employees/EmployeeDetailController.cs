using DanM.Core.Facades.ModelDescriptors.Employees;
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
	private readonly IEmployeeDescriptor _entityDesc;

	public EmployeeDetailController(
		IDetailControllerServices services,
		IEmployeeDescriptor entityDesc)
		: base(services)
	{
		_entityDesc = entityDesc;
	}

	protected override void OnBindingProperties(DetailBindingContext ctx)
	{
		base.OnBindingProperties(ctx);

		this.Binders.TextBinder.Bind(ctx, this.Data.tbxFirstName, _entityDesc.FirstName);
		this.Binders.TextBinder.Bind(ctx, this.Data.tbxLastName, _entityDesc.LastName);
		this.Binders.TextBinder.Bind(ctx, this.Data.tbxPersonalNumber, _entityDesc.PersonalNumber);
	}
}

public interface IEmployeeDetailController : IDetailControllerBase<EmployeeDetailData>
{
}