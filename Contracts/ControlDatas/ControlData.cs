namespace DanM.Core.Contracts.ControlDatas;

public class ControlData : IControlData
{
	public bool IsEditable { get; set; }
	public ControlData ParentData { get; set; }

	public ControllerData GetControllerData()
	{
		return this.GetParentDatas().OfType<ControllerData>().FirstOrDefault();
	}

	public IEnumerable<ControlData> GetParentDatas()
	{
		var parent = this.ParentData;
		while (parent != null)
		{
			yield return parent;
			parent = parent.ParentData;
		}
	}
}

public interface IControlData
{
	ControlData ParentData { get; set; }
}