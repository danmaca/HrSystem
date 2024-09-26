using DanM.HrSystem.Contracts.Framework.Controllers;
using Havit;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeDetailPage
{
	[Parameter] public EventCallback<EmployeeDetailData> OnEntryCreated { get; set; }
	[Parameter] public EventCallback<EmployeeDetailData> OnEntryUpdated { get; set; }

	[Inject] protected IControllerManager ControllerManager { get; set; }

	private async Task HandleCreateOrUpdateButtonClick()
	{
	}

	private async Task HandleEditable()
	{
		//this.Data = await this.Controller.GetDetailDataAsync(this.Data);
		//editContext = new EditContext(this.Data);
		//this.Data.tbxFirstName.IsEditable = !this.Data.tbxFirstName.IsEditable;
	}

	private async Task CreateNewEntry()
	{
		Contract.Assert(Data.Setup.EntityId == null, "Záznam již není nový.");

		try
		{
			//this.Entity.Id = (await EntryFacade.CreateEntryAsync(this.Entity)).Value;
			await OnEntryCreated.InvokeAsync(this.Data);
		}
		catch (OperationFailedException)
		{
			// NOOP
		}
	}
}