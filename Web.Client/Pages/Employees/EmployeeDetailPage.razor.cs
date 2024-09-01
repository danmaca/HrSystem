using DanM.HrSystem.Contracts.ControlDatas;
using Havit;
using Microsoft.AspNetCore.Components.Forms;

namespace DanM.HrSystem.Web.Client.Pages.Employees;

public partial class EmployeeDetailPage
{
	[Parameter] public int? Id { get; set; }
	[Parameter] public EmployeeDetailDto Entity { get; set; }
	[Parameter] public EventCallback OnEntryDeleted { get; set; }
	[Parameter] public EventCallback<EmployeeDetailDto> OnEntryCreated { get; set; }
	[Parameter] public EventCallback<EmployeeDetailDto> OnEntryUpdated { get; set; }
	[Parameter] public EventCallback OnCloseButtonClicked { get; set; }

	[Inject] protected IEmployeeFacade EmployeeFacade { get; set; }

	private EditContext editContext;

	private bool EdittingEntry => Entity.Id != default;
	private bool RenderCloseButton => OnCloseButtonClicked.HasDelegate;

	protected override void OnInitialized()
	{
		this.Entity = new EmployeeDetailDto();
		this.Entity.tbxFirstName = new TextControlData();
		this.Entity.tbxFirstName.CaptionText = "jmeno";
		this.Entity.tbxFirstName.Text = "moje";
		editContext = new EditContext(this.Entity);
	}

	protected override void OnParametersSet()
	{
		//editContext = new EditContext(Entity);
	}

	private async Task HandleCreateOrUpdateButtonClick()
	{
		this.Entity.tbxFirstName.Text += "x";
		return;

		if (Entity.Id == default)
		{
			await CreateNewEntry();
		}
		else
		{
			await UpdateEntry();
		}
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