namespace DanM.HrSystem.Contracts;

public class EntityRequestInfo
{
	public int? EntityId { get; set; }

	public EntityRequestInfo()
	{
	}
	public EntityRequestInfo(int? entityId)
	{
		this.EntityId = entityId;
	}
}