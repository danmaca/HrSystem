using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Web.Client.Controls.Framework;

public class CaptionControlBase<TData> : DataControlBase<TData>, ICaptionControlBase
	where TData : CaptionControlData
{
	CaptionControlData IDataControlBase<CaptionControlData>.ControlData { get => this.Data; set => this.Data = (TData)value; }
}

public interface ICaptionControlBase : IDataControlBase<CaptionControlData>
{
}