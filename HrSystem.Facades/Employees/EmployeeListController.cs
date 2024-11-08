using DanM.Core.Services.Controllers;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.Model.Employees;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Employees;

[Service]
[Authorize]
public class EmployeeListController : EntityListControllerBase<Employee, EmployeeListData>, IEmployeeListController
{
	public EmployeeListController(
		IListControllerServices services)
		: base(services)
	{
	}
}

public interface IEmployeeListController : IEntityListControllerBase<Employee, EmployeeListData>
{
}