using DanM.Core.Contracts.ControlDatas;

namespace DanM.HrSystem.Web.Client.Framework;

public abstract class ListPageBase<TData> : DataPageBase<TData>
	where TData : ListControllerData, new()
{
}