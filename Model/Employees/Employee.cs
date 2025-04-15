using System.ComponentModel.DataAnnotations;
using DanM.Core.Model.Framework;
using DanM.HrSystem.Model.Agreements;
using DanM.HrSystem.Model.Security;
using DanM.HrSystem.Primitives.Common;

namespace DanM.HrSystem.Model.Employees;

public class Employee : IJournaledEntity
{
	public int Id { get; set; }

	public User CreatedBy { get; set; }
	public int CreatedById { get; set; }
	public DateTimeOffset CreatedDtt { get; set; }

	public User UpdatedBy { get; set; }
	public int? UpdatedById { get; set; }
	public DateTimeOffset? UpdatedDtt { get; set; }

	[Required]
	[MaxLength(30)]
	public string FirstName { get; set; }

	[Required]
	[MaxLength(30)]
	public string LastName { get; set; }

	[MaxLength(10)]
	public string PersonalNumber { get; set; }

	[MaxLength(255)]
	public string Email { get; set; }

	[Required]
	public EntityState State { get; set; } = EntityState.Active;

	public ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();
}
