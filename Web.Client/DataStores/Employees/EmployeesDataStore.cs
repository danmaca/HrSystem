using DanM.HrSystem.Contracts.Employees;
using Havit.Blazor.Components.Web.Services.DataStores;

namespace DanM.HrSystem.Web.Client.DataStores.Employees;

public class EmployeesDataStore : DictionaryStaticDataStore<int, EmployeeGridDto>, IEmployeesDataStore
{
	private readonly IEmployeeFacade _employeeFacade;

	public EmployeesDataStore(IEmployeeFacade employeeFacade)
	{
		_employeeFacade = employeeFacade;
	}

	protected override Func<EmployeeGridDto, int> KeySelector { get; } = (dto) => dto.EmployeeId;

	protected override async Task<IEnumerable<EmployeeGridDto>> LoadDataAsync()
	{
		return await _employeeFacade.GetDtosAsync(new EmployeeListFilter());
	}

	protected override bool ShouldRefresh() => false;
}

public interface IEmployeesDataStore : IDictionaryStaticDataStore<int, EmployeeGridDto>
{
}