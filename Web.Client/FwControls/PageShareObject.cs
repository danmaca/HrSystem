using DanM.Core.Web.Client.Framework;

namespace DanM.Core.Web.Client.FwControls;

public class PageShareObject
{
	public PageBase OwnerPage { get; set; }
	public IDataPageBase OwnerDataPage => OwnerPage as IDataPageBase;
}