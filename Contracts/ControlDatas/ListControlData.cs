using DanM.Core.Contracts.Collections;
using DanM.Core.Contracts.Filtering;
using DanM.Core.Contracts.Utils;

namespace DanM.Core.Contracts.ControlDatas;

public class ListControlData : ControlData
{
	public ListSource<object> DataSource { get; set; }
	public int PageSize { get; set; } = 1;

	public IFilterBase DataFilter { get; set; }
	public string DtosFetchFacadeTypeName { get; set; }
	public bool IsSourceRefreshRequested { get; set; }

	public async Task FillDataAsync(object dtosFetchFacade, IFilterBase dataFilter)
	{
		this.DataFilter = dataFilter;
		this.DtosFetchFacadeTypeName = dtosFetchFacade.GetType().GetInterfaces().First().AssemblyQualifiedName;
		this.IsSourceRefreshRequested = true;
		this.DataSource = await this.FetchInitialRowsAsync(dtosFetchFacade, dataFilter);
	}

	public async Task<ListSource<object>> FetchInitialRowsAsync(object dtosFetchFacade, IFilterBase dataFilter)
	{
		dataFilter.Paging.StartRowIndex = 0;
		dataFilter.Paging.RowsCount = this.PageSize;

		return await FacadeCaller.FetchDtosAsync(dtosFetchFacade, dataFilter);
	}
}
