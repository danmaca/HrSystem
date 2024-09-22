using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.Employees;
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
	private readonly IStandardBinders _binders;
	private readonly IEmployeeDescriptor _employeeDescriptor;
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EmployeeDetailController(
		IStandardBinders binders,
		IEmployeeDescriptor employeeDescriptor,
		IEmployeeRepository employeeRepository,
		IUnitOfWork unitOfWork)
	{
		_binders = binders;
		_employeeDescriptor = employeeDescriptor;
		_employeeRepository = employeeRepository;
		_unitOfWork = unitOfWork;
	}

	protected override async Task<Employee> OnCreateEntityAsync()
	{
		Employee entity;
		if (this.Data.EntityId != null)
			entity = await _employeeRepository.GetObjectAsync(this.Data.EntityId.Value);
		else
			entity = new Employee();
		return entity;
	}

	protected override void OnBindingProperties()
	{
		base.OnBindingProperties();

		var ctx = new BindingContext();
		ctx.Mode = BindingMode.UpdateForm;
		ctx.BindingEntity = this.Entity;

		_binders.TextBinder.Bind(ctx, this.Data.tbxFirstName, _employeeDescriptor.FirstNameProp);
		_binders.TextBinder.Bind(ctx, this.Data.tbxLastName, _employeeDescriptor.LastNameProp);
	}

	public async Task<Dto<int>> PersistDetailDtoAsync(EmployeeDetailData dto, CancellationToken cancellationToken = default)
	{
		Employee entity;
		if (dto.EntityId != null)
			entity = await _employeeRepository.GetObjectAsync(dto.EntityId.Value, cancellationToken);
		else
			entity = new Employee();

		entity.FirstName = dto.tbxFirstName.Text;
		entity.LastName = dto.tbxLastName.Text;

		if (dto.EntityId != null)
			_unitOfWork.AddForUpdate(entity);
		else
			_unitOfWork.AddForInsert(entity);

		await _unitOfWork.CommitAsync(cancellationToken);
		return Dto.FromValue(entity.Id);
	}
}