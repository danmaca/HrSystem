using DanM.Core.Contracts.Collections;
using DanM.Core.Contracts.Utils;
using DanM.HrSystem.Web.Client.FwControls;
using Havit;

namespace DanM.Core.Web.Client.Controls;

[CascadingTypeParameter(nameof(TItem))]
public partial class GridView<TItem>
{
	[Parameter, EditorRequired] public RenderFragment Columns { get; set; }
	[Inject]
	private IServiceProvider ServiceProvider { get; set; }

	private GridDataProviderDelegate<TItem> DataProvider { get; set; }
	private GridViewControl<TItem> conGrid;

	public GridView()
	{
		this.DataProvider = this.GetGridDataAsync;
	}

	protected async override Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();

		if (Data == null || conGrid == null)
			return;

		if (Data.IsSourceRefreshRequested)
		{
			await conGrid.RefreshDataAsync();
			Data.IsSourceRefreshRequested = false;
		}
	}

	private async Task<GridDataProviderResult<TItem>> GetGridDataAsync(GridDataProviderRequest<TItem> request)
	{
		if (this.Data == null)
		{
			return new GridDataProviderResult<TItem>()
			{
				Data = null,
				TotalCount = 0,
			};
		}

		try
		{
			if (this.Data.DataFilter != null && this.Data.DtosFetchFacadeTypeName != null)
			{
				var filter = this.Data.DataFilter;
				filter.Paging.StartRowIndex = request.StartIndex;
				filter.Paging.RowsCount = request.Count;

				var gridDataSource = await FacadeCaller.FetchDtosAsync<TItem>(this.Data.DtosFetchFacadeTypeName, filter, this.ServiceProvider, request.CancellationToken);
				return new GridDataProviderResult<TItem>()
				{
					Data = gridDataSource.Items,
					TotalCount = gridDataSource.TotalCount,
				};
			}
		}
		catch (OperationFailedException)
		{
			return new() { Data = null, TotalCount = 0 };
		}
		return null;
	}
}