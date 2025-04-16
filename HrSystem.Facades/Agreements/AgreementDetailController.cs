using DanM.Core.Facades.ModelDescriptors.Agreements;
using DanM.Core.Services.Binders;
using DanM.Core.Services.Controllers;
using DanM.HrSystem.Contracts.Agreements;
using DanM.HrSystem.DataLayer.Repositories.Agreements;
using DanM.HrSystem.Model.Agreements;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Agreements;

[Service]
[Authorize]
public class AgreementDetailController : EntityDetailControllerBase<Agreement, IAgreementRepository, AgreementDetailData>, IAgreementDetailController
{
	private readonly IAgreementDescriptor _agreementDescriptor;

	public AgreementDetailController(
		IDetailControllerServices services,
		IAgreementDescriptor agreementDescriptor)
		: base(services)
	{
		_agreementDescriptor = agreementDescriptor;
	}

	protected override void OnBindingProperties(DetailBindingContext ctx)
	{
		base.OnBindingProperties(ctx);

		this.Binders.TextBinder.Bind(ctx, this.Data.tbxName, _agreementDescriptor.Name);
		this.Binders.DateOnlyBinder.Bind(ctx, this.Data.dtpValidFrom, _agreementDescriptor.ValidFrom);
		this.Binders.DateOnlyBinder.Bind(ctx, this.Data.dtpValidTo, _agreementDescriptor.ValidTo);
	}
}

public interface IAgreementDetailController : IDetailControllerBase<AgreementDetailData>
{
}