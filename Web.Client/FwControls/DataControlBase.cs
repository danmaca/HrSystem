using DanM.Core.Contracts.ControlDatas;

namespace DanM.HrSystem.Web.Client.FwControls;

public class DataControlBase<TData> : ControlBase, IDataControlBase<TData>
	where TData : IControlData
{
	public IControlData ControlData { get => Data; set => Data = (TData)value; }
	[Parameter] public TData Data { get; set; }

	TData IDataControlBase<TData>.ControlData { get => Data; set => Data = value; }
}

public interface IDataControlBase : IDataControlBase<IControlData>
{
}

public interface IDataControlBase<TData> : IControlBase
	where TData : IControlData
{
	TData ControlData { get; set; }
}