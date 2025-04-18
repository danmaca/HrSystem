using DanM.Core.Contracts.Filtering;

namespace DanM.Core.Contracts.ControlDatas;

public class ListControlData : ControlData
{
	public List<object> DataRows { get; set; }
	public int PageSize { get; set; } = 1;

	public IFilterBase DataFilter { get; set; }
	public string DtosFetchFacadeTypeName { get; set; }
	public bool IsSourceRefreshRequested { get; set; }

	public void FillData(IFilterBase dataFilter, Type dtosFetchFacadeType)
	{
		this.DataFilter = dataFilter;
		this.DtosFetchFacadeTypeName = dtosFetchFacadeType.AssemblyQualifiedName;
		this.IsSourceRefreshRequested = true;
	}
}
