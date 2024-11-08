using DanM.Core.Contracts.ControlDatas;

namespace DanM.Core.Web.Client.Controls;

public partial class ActionButtonizer
{
	private async Task OnClickInvokedAsync(ActionButtonDto action)
	{
		Data.InvokedActionKey = action.UniqueKey;
		await PageShare.OwnerDataPage.DoPageDataPostback();
	}
}