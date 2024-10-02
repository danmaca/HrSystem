using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.DataLayer.Repositories.Employees;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Employees;

[Service]
[Authorize]
public class EmployeeFacade : IEmployeeFacade
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EmployeeFacade(
		IEmployeeRepository employeeRepository,
		IUnitOfWork unitOfWork)
	{
		_employeeRepository = employeeRepository;
		_unitOfWork = unitOfWork;
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