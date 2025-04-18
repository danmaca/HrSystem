using DanM.Core.Contracts.Collections;
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

	public async Task<ListSource<EmployeeGridDto>> GetDtosAsync(EmployeeListFilter filter, CancellationToken cancellationToken = default)
	{
		var employees = await _employeeRepository.GetByFilterAsync(filter, cancellationToken);
		return employees.Transform(obj => new EmployeeGridDto()
		{
			EmployeeId = obj.Id,
			FirstName = obj.FirstName,
			LastName = obj.LastName,
			State = obj.State,
		});
	}
}