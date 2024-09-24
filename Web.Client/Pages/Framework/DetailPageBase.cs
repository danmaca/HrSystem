using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Web.Client.Pages.Framework;

public abstract class DetailPageBase<TData> : DataPageBase<TData>
	where TData : DetailControllerData, new()
{
	[Parameter] public int? EntityId { get; set; }

	protected bool IsNewEntity => this.Data?.Setup.EntityId == null;

	protected override void PrepareControllerData()
	{
		base.PrepareControllerData();

		this.Data.Setup.EntityId = this.EntityId;
	}
}