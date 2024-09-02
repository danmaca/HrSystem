using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.ControlDatas;
using Havit;
using Microsoft.AspNetCore.Components.Forms;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeDetailPage
{
	[Parameter] public int? EntityId { get; set; }
	[Parameter] public EmployeeDetailDto Entity { get; set; }
	[Parameter] public EventCallback<EmployeeDetailDto> OnEntryCreated { get; set; }
	[Parameter] public EventCallback<EmployeeDetailDto> OnEntryUpdated { get; set; }

	[Inject] protected IEmployeeFacade EmployeeFacade { get; set; }

	private EditContext editContext;

	private bool EdittingEntry => Entity.Id != default;

	protected override async Task OnInitializedAsync()
	{
		this.Entity = await this.EmployeeFacade.GetEmployeeDetailDtoAsync(new EntityRequestInfo(this.EntityId));
		editContext = new EditContext(this.Entity);
	}

	private async Task HandleCreateOrUpdateButtonClick()
	{
		var dto = (EmployeeDetailDto)editContext.Model;
		dto.Id = this.EntityId;
		var result = await this.EmployeeFacade.PersistEmployeeDetailDtoAsync(dto);
		this.EntityId = result.Value;
		dto.Id = result.Value;
	}

	private async Task HandleEditable()
	{
		this.Entity.tbxFirstName.IsEditable = !this.Entity.tbxFirstName.IsEditable;
	}

	private async Task CreateNewEntry()
	{
		Contract.Assert(Entity.Id == default, "Záznam již není nový.");

		try
		{
			//this.Entity.Id = (await EntryFacade.CreateEntryAsync(this.Entity)).Value;
			await OnEntryCreated.InvokeAsync(this.Entity);
		}
		catch (OperationFailedException)
		{
			// NOOP
		}
	}

	private async Task UpdateEntry()
	{
		if (Entity.Id == default)
		{
			return;
		}

		if (editContext.Validate())
		{
			try
			{
				//await EntryFacade.UpdateEntryAsync(this.Entity);
				await OnEntryUpdated.InvokeAsync(this.Entity);
			}
			catch (OperationFailedException)
			{
				// NOOP
			}
		}
	}
}