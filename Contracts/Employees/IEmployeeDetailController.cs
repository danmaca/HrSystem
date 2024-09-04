namespace DanM.HrSystem.Contracts.Employees;

[ApiContract]
public interface IEmployeeDetailController
{
	Task<EmployeeDetailDto> GetDetailDtoAsync(EntityRequestInfo info, CancellationToken cancellationToken = default);
	Task<Dto<int>> PersistDetailDtoAsync(EmployeeDetailDto dto, CancellationToken cancellationToken = default);
}