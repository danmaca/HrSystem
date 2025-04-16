using DanM.Core.Primitives.Common;

namespace DanM.HrSystem.Contracts.Agreements;

public class AgreementGridDto
{
	public int AgreementId { get; set; }
	public string Name { get; set; }
	public DateOnly ValidFrom { get; set; }
	public DateOnly ValidTo { get; set; }
	public string OwnerEmployeeFullName { get; set; }
	public EntityState State { get; set; }
}