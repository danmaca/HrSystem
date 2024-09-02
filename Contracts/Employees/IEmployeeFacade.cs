namespace DanM.HrSystem.Contracts.Employees;

[ApiContract]
public interface IEmployeeFacade
{
	Task<List<EmployeeGridDto>> GetAllEmployeesAsync(CancellationToken cancellationToken = default);
	Task<EmployeeDetailDto> GetEmployeeDetailDtoAsync(EntityRequestInfo info, CancellationToken cancellationToken = default);
	Task<Dto<int>> PersistEmployeeDetailDtoAsync(EmployeeDetailDto dto, CancellationToken cancellationToken = default);
}