using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.DataLayer.Repositories.Employees;
using DanM.HrSystem.Model.Employees;
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

	public async Task<EmployeeDetailDto> GetEmployeeDetailDtoAsync(GetEmployeeDetailDtoInfo info, CancellationToken cancellationToken = default)
	{
		int? entityId = 1;
		var dto = new EmployeeDetailDto();
		dto.tbxFirstName.Text = "jmeno";
		dto.tbxLastName.Text = "prijmeni";

		Employee entity;
		if (entityId != null)
			entity = await _employeeRepository.GetObjectAsync(entityId.Value, cancellationToken);
		else
			entity = new Employee();

		dto.tbxFirstName.Text = entity.FirstName;
		dto.tbxLastName.Text = entity.LastName;
		return dto;
	}
}