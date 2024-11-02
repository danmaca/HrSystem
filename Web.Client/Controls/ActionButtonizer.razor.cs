using DanM.Core.Contracts.ControlDatas;

namespace DanM.HrSystem.Web.Client.Controls;

public partial class ActionButtonizer
{
	private async Task OnClickInvokedAsync(ActionButtonDto action)
	{
		this.Data.InvokedActionKey = action.UniqueKey;
		await this.PageShare.OwnerDataPage.DoPageDataPostback();
	}
}