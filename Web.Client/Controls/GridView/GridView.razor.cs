using DanM.Core.Contracts.Collections;
using DanM.HrSystem.Contracts.Employees;
using Havit;

namespace DanM.Core.Web.Client.Controls;

[CascadingTypeParameter(nameof(TItem))]
public partial class GridView<TItem>
{
	[Parameter, EditorRequired] public RenderFragment Columns { get; set; }
	[Inject]
	private IServiceProvider ServiceProvider { get; set; }

	private GridDataProviderDelegate<TItem> DataProvider { get; set; }

	public GridView()
	{
		this.DataProvider = this.GetGridDataAsync;
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
				Type dtosFetchFacadeType = Type.GetType(this.Data.DtosFetchFacadeTypeName);
				var getDtosMethodMember = dtosFetchFacadeType.GetMethod("GetDtosAsync");

				var filter = this.Data.DataFilter;
				filter.PagingStartRowIndex = request.StartIndex;
				filter.PagingRowsCount = request.Count;

				var dtosFetchFacade = this.ServiceProvider.GetRequiredService(dtosFetchFacadeType);
				var gridDataTask = (Task<ListSource<TItem>>)getDtosMethodMember.Invoke(dtosFetchFacade, new object[] { filter, request.CancellationToken });
				var gridDataSource = await gridDataTask;
				return new GridDataProviderResult<TItem>()
				{
					Data = gridDataSource,
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