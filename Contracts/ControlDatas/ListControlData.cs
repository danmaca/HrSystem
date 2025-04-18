using DanM.Core.Contracts.Filtering;

namespace DanM.Core.Contracts.ControlDatas;

public class ListControlData : ControlData
{
	public IFilterBase DataFilter { get; set; }
	public List<object> DataRows { get; set; }

	public void FillData(IFilterBase DataFilter, Type facadeType)
	{
	}
}
