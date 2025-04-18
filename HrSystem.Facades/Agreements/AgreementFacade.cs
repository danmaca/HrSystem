using DanM.HrSystem.Contracts.Agreements;
using DanM.HrSystem.DataLayer.Repositories.Agreements;
using Havit.Data.Patterns.UnitOfWorks;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Agreements;

[Service]
[Authorize]
public class AgreementFacade : IAgreementFacade
{
	private readonly IAgreementRepository _agreementRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AgreementFacade(
		IAgreementRepository agreementRepository,
		IUnitOfWork unitOfWork)
	{
		_agreementRepository = agreementRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<List<AgreementGridDto>> GetDtosAsync(CancellationToken cancellationToken = default)
	{
		var employees = await _agreementRepository.GetAllAsync(cancellationToken);
		return employees.Select(obj => new AgreementGridDto()
		{
			AgreementId = obj.Id,
			Name = obj.Name,
			OwnerEmployeeFullName = obj.OwnerEmployee?.LastName + " " + obj.OwnerEmployee?.FirstName,
			State = obj.State,
		}).ToList();
	}
}