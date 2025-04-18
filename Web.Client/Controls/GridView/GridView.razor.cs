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

				var dtosFetchFacade = this.ServiceProvider.GetRequiredService(dtosFetchFacadeType);
				var gridDataTask = (Task<List<TItem>>)getDtosMethodMember.Invoke(dtosFetchFacade, new object[] { this.Data.DataFilter, request.CancellationToken });
				var gridData = await gridDataTask;
				return new GridDataProviderResult<TItem>()
				{
					Data = gridData,
					TotalCount = 100
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