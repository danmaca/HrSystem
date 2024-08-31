using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.DataLayer.Repositories.Employees;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Employees;

[Service]
[Authorize]
public class EmployeeFacade : IEmployeeFacade
{
	private readonly IEmployeeRepository _employeeRepository;

	public EmployeeFacade(IEmployeeRepository employeeRepository)
	{
		_employeeRepository = employeeRepository;
	}

	public async Task<List<EmployeeGridDto>> GetAllEmployeesAsync(CancellationToken cancellationToken = default)
	{
		var employees = await _employeeRepository.GetAllAsync(cancellationToken);
		return employees.Select(e => new EmployeeGridDto()
		{
			EmployeeId = e.Id,
			FirstName = e.FirstName,
			LastName = e.LastName,
			State = e.State,
		}).ToList();
	}
}