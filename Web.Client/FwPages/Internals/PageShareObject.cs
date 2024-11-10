using DanM.Core.Web.Client.FwPages;

namespace DanM.HrSystem.Web.Client.FwPages.Internals;

public class PageShareObject
{
	public PageBase OwnerPage { get; set; }
	public IDataPageBase OwnerDataPage => OwnerPage as IDataPageBase;
}