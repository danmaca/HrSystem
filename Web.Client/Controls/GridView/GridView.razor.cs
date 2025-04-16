namespace DanM.Core.Web.Client.Controls;

[CascadingTypeParameter(nameof(TItem))]
public partial class GridView<TItem>
{
	[Parameter, EditorRequired] public GridDataProviderDelegate<TItem> DataProvider { get; set; }
	[Parameter, EditorRequired] public RenderFragment Columns { get; set; }
}