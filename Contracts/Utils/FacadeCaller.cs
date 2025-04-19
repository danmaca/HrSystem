using DanM.Core.Contracts.Collections;
using DanM.Core.Contracts.Filtering;
using DanM.HrSystem.Primitives.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Contracts.Utils;

public static class FacadeCaller
{
	public static async Task<ListSource<TDto>> FetchDtosAsync<TDto>(string facadeTypeName, IFilterBase filter, IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
	{
		Type dtosFetchFacadeType = Type.GetType(facadeTypeName);
		var dtosFetchFacade = serviceProvider.GetRequiredService(dtosFetchFacadeType);
		return await FetchDtosAsync<TDto>(dtosFetchFacade, filter, cancellationToken);
	}

	public static async Task<ListSource<TDto>> FetchDtosAsync<TDto>(object dtosFetchFacade, IFilterBase filter, CancellationToken cancellationToken = default)
	{
		var getDtosMethodMember = MethodHelper.FindMethod(dtosFetchFacade.GetType(), "GetDtosAsync");
		var gridDataTask = (Task<ListSource<TDto>>)getDtosMethodMember.Invoke(dtosFetchFacade, new object[] { filter, cancellationToken });
		return await gridDataTask;
	}

	public static async Task<ListSource<object>> FetchDtosAsync(object dtosFetchFacade, IFilterBase filter, CancellationToken cancellationToken = default)
	{
		var getDtosMethodMember = MethodHelper.FindMethod(dtosFetchFacade.GetType(), "GetDtosAsync");
		var gridDataTask = (Task)getDtosMethodMember.Invoke(dtosFetchFacade, new object[] { filter, cancellationToken });
		await gridDataTask;
		var source = (IListSource)gridDataTask.GetType().GetProperty("Result").GetValue(gridDataTask);
		return new ListSource<object>(source.Items, source.TotalCount);
	}
}