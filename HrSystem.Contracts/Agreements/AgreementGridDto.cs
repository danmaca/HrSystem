using DanM.HrSystem.Primitives.Common;

namespace DanM.HrSystem.Contracts.Agreements;

public class AgreementGridDto
{
	public int AgreementId { get; set; }
	public string Name { get; set; }
	public string OwnerEmployeeFirstName { get; set; }
	public string OwnerEmployeeLastName { get; set; }
	public EntityState State { get; set; }
}