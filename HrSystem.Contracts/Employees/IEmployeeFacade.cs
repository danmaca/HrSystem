namespace DanM.HrSystem.Contracts.Employees;

[ApiContract]
public interface IEmployeeFacade
{
	Task<List<EmployeeGridDto>> GetDtosAsync(EmployeeListFilter filter, CancellationToken cancellationToken = default);
}