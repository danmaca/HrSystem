using DanM.Core.Contracts.ControlDatas;

namespace DanM.Core.Web.Client.FwControls;

public class CaptionControlBase<TData> : DataControlBase<TData>, ICaptionControlBase
	where TData : ICaptionControlData
{
	ICaptionControlData IDataControlBase<ICaptionControlData>.ControlData { get => Data; set => Data = (TData)value; }
}

public interface ICaptionControlBase : IDataControlBase<ICaptionControlData>
{
}