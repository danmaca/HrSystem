using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Web.Client.Controls.Framework;

public class DataControlBase<TData> : ControlBase, IDataControlBase<TData>
	where TData : ControlData
{
	public ControlData ControlData { get => this.Data; set => this.Data = (TData)value; }
	[Parameter] public TData Data { get; set; }

	TData IDataControlBase<TData>.ControlData { get => this.Data; set => this.Data = value; }
}

public interface IDataControlBase : IDataControlBase<ControlData>
{
}

public interface IDataControlBase<TData> : IControlBase
	where TData : ControlData
{
	TData ControlData { get; set; }
}