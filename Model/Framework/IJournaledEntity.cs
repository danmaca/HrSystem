using DanM.HrSystem.Model.Security;

namespace DanM.Core.Model.Framework;

public interface IJournaledEntity : IEntity
{
	User CreatedBy { get; set; }
	int CreatedById { get; set; }
	DateTimeOffset CreatedDtt { get; set; }

	User UpdatedBy { get; set; }
	int? UpdatedById { get; set; }
	DateTimeOffset? UpdatedDtt { get; set; }
}
