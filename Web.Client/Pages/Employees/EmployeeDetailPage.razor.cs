using Havit;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeDetailPage
{
	[Parameter] public EventCallback<EmployeeDetailData> OnEntryCreated { get; set; }
	[Parameter] public EventCallback<EmployeeDetailData> OnEntryUpdated { get; set; }

	[Inject] protected IEmployeeDetailController Controller { get; set; }

	protected override async Task<EmployeeDetailData> CallControllerRequest()
	{
		return await this.Controller.GetDetailDataAsync(this.Data);
	}

	private async Task HandleCreateOrUpdateButtonClick()
	{
		var dto = (EmployeeDetailData)conEditContext.Model;
		var result = await this.Controller.PersistDetailDtoAsync(dto);
		dto.EntityId = result.Value;
	}

	private async Task HandleEditable()
	{
		//this.Data = await this.Controller.GetDetailDataAsync(this.Data);
		//editContext = new EditContext(this.Data);
		//this.Data.tbxFirstName.IsEditable = !this.Data.tbxFirstName.IsEditable;
	}

	private async Task CreateNewEntry()
	{
		Contract.Assert(Data.EntityId == null, "Záznam již není nový.");

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

	private async Task UpdateEntry()
	{
		if (Data.EntityId == null)
		{
			return;
		}

		if (conEditContext.Validate())
		{
			try
			{
				//await EntryFacade.UpdateEntryAsync(this.Entity);
				await OnEntryUpdated.InvokeAsync(this.Data);
			}
			catch (OperationFailedException)
			{
				// NOOP
			}
		}
	}
}