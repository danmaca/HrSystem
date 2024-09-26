using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.Employees;
using DanM.HrSystem.Contracts.Framework.Controllers;
using DanM.HrSystem.DataLayer.Repositories.Employees;
using DanM.HrSystem.Facades.Framework.Controllers;
using DanM.HrSystem.Facades.ModelDescriptors;
using DanM.HrSystem.Model.Employees;
using DanM.HrSystem.Services.Framework.Binders;
using Havit.Data.Patterns.UnitOfWorks;
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
	private readonly IUnitOfWork _unitOfWork;

	public EmployeeDetailController(
		IDetailControllerServices services,
		IEmployeeDescriptor employeeDescriptor,
		IEmployeeRepository employeeRepository,
		IUnitOfWork unitOfWork)
		: base(services)
	{
		_services = services;
		_employeeDescriptor = employeeDescriptor;
		_employeeRepository = employeeRepository;
		_unitOfWork = unitOfWork;
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

	public async Task<Dto<int>> PersistDetailDtoAsync(EmployeeDetailData dto, CancellationToken cancellationToken = default)
	{
		Employee entity;
		if (dto.Setup.EntityId != null)
			entity = await _employeeRepository.GetObjectAsync(dto.Setup.EntityId.Value, cancellationToken);
		else
			entity = new Employee();

		entity.FirstName = dto.tbxFirstName.Text;
		entity.LastName = dto.tbxLastName.Text;

		if (dto.Setup.EntityId != null)
			_unitOfWork.AddForUpdate(entity);
		else
			_unitOfWork.AddForInsert(entity);

		await _unitOfWork.CommitAsync(cancellationToken);
		return Dto.FromValue(entity.Id);
	}
}

public interface IEmployeeDetailController : IDetailControllerBase<EmployeeDetailData>
{
}