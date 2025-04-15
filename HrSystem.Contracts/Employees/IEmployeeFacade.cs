namespace DanM.HrSystem.Contracts.Employees;

[ApiContract]
public interface IEmployeeFacade
{
	Task<List<EmployeeGridDto>> GetItemsAsync(CancellationToken cancellationToken = default);
}