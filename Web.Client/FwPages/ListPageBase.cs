using DanM.Core.Contracts.ControlDatas;

namespace DanM.Core.Web.Client.FwPages;

public abstract class ListPageBase<TData> : DataPageBase<TData>
	where TData : ListControllerData, new()
{
}