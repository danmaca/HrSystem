using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Controllers;
using DanM.Core.Contracts.Navigation;

namespace DanM.Core.Web.Client.Framework;

public abstract class DetailPageBase<TData> : DataPageBase<TData>
	where TData : DetailControllerData, new()
{
	[Parameter] public int? EntityId { get; set; }

	protected bool IsNewEntity => Data?.Setup.EntityId == null;

	protected override void InitialControllerRequest(ControllerCallRequest request)
	{
		base.InitialControllerRequest(request);

		request.Navigation.Params.Add(new NavigationParam()
		{
			Name = "Id",
			Value = this.EntityId?.ToString(),
		});
	}
}