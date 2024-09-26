using System.Runtime.Serialization;
using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Framework.Controllers;

[DataContract]
public class ControllerCallResponse
{
	[DataMember]
	public IControllerData ContentData { get; set; }
}