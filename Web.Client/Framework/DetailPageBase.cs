using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Contracts.Framework.Controllers;
using DanM.HrSystem.Contracts.Framework.Navigation;

namespace DanM.HrSystem.Web.Client.Framework;

public abstract class DetailPageBase<TData> : DataPageBase<TData>
	where TData : DetailControllerData, new()
{
	[Parameter] public int? EntityId { get; set; }

	protected bool IsNewEntity => Data?.Setup.EntityId == null;

	protected override void InitialControllerRequest(ControllerCallRequest request)
	{
		base.InitialControllerRequest(request);

		request.ContentDataTypeName = typeof(TData).FullName;

		request.Navigation.Params.Add(new NavigationParam()
		{
			Name = "Id",
			Value = this.EntityId?.ToString(),
		});
	}
}