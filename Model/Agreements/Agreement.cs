using System.ComponentModel.DataAnnotations;
using DanM.Core.Model.Framework;
using DanM.Core.Primitives.Common;
using DanM.HrSystem.Model.Employees;
using DanM.HrSystem.Model.Security;

namespace DanM.HrSystem.Model.Agreements;

public class Agreement : IJournaledEntity
{
	public int Id { get; set; }

	public User CreatedBy { get; set; }
	public int CreatedById { get; set; }
	public DateTimeOffset CreatedDtt { get; set; }

	public User UpdatedBy { get; set; }
	public int? UpdatedById { get; set; }
	public DateTimeOffset? UpdatedDtt { get; set; }

	[Required]
	[MaxLength(300)]
	public string Name { get; set; }

	[Required]
	public EntityState State { get; set; } = EntityState.Active;

	public DateOnly ValidFrom { get; set; }
	public DateOnly ValidTo { get; set; }

	public Employee OwnerEmployee { get; set; }
	public int? OwnerEmployeeId { get; set; }
}
