using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.DataLayer.Repositories.Employees;
using DanM.HrSystem.Model.Employees;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Employees;

[Service]
[Authorize]
public class EmployeeDetailController : IEmployeeDetailController
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EmployeeDetailController(
		IEmployeeRepository employeeRepository,
		IUnitOfWork unitOfWork)
	{
		_employeeRepository = employeeRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<EmployeeDetailDto> GetDetailDtoAsync(EntityRequestInfo info, CancellationToken cancellationToken = default)
	{
		var dto = new EmployeeDetailDto();
		dto.tbxFirstName.CaptionText = "Jméno";
		dto.tbxLastName.CaptionText = "Příjmení";

		Employee entity;
		if (info.EntityId != null)
			entity = await _employeeRepository.GetObjectAsync(info.EntityId.Value, cancellationToken);
		else
			entity = new Employee();

		dto.tbxFirstName.Text = entity.FirstName;
		dto.tbxLastName.Text = entity.LastName;
		return dto;
	}

	public async Task<Dto<int>> PersistDetailDtoAsync(EmployeeDetailDto dto, CancellationToken cancellationToken = default)
	{
		Employee entity;
		if (dto.Id != null)
			entity = await _employeeRepository.GetObjectAsync(dto.Id.Value, cancellationToken);
		else
			entity = new Employee();

		entity.FirstName = dto.tbxFirstName.Text;
		entity.LastName = dto.tbxLastName.Text;

		if (dto.Id != null)
			_unitOfWork.AddForUpdate(entity);
		else
			_unitOfWork.AddForInsert(entity);

		await _unitOfWork.CommitAsync(cancellationToken);
		return Dto.FromValue(entity.Id);
	}
}