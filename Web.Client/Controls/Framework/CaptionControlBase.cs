﻿using DanM.Core.Contracts.ControlDatas;

namespace DanM.HrSystem.Web.Client.Controls.Framework;

public class CaptionControlBase<TData> : DataControlBase<TData>, ICaptionControlBase
	where TData : ICaptionControlData
{
	ICaptionControlData IDataControlBase<ICaptionControlData>.ControlData { get => this.Data; set => this.Data = (TData)value; }
}

public interface ICaptionControlBase : IDataControlBase<ICaptionControlData>
{
}