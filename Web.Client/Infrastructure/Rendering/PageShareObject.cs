using DanM.HrSystem.Web.Client.Framework;

namespace DanM.HrSystem.Web.Client.Infrastructure.Rendering;

public class PageShareObject
{
	public PageBase OwnerPage { get; set; }
	public IDataPageBase OwnerDataPage => this.OwnerPage as IDataPageBase;
}