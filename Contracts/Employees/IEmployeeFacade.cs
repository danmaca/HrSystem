namespace DanM.HrSystem.Contracts.Employees;

[ApiContract]
public interface IEmployeeFacade
{
	Task<List<EmployeeGridDto>> GetAllEmployeesAsync(CancellationToken cancellationToken = default);
}