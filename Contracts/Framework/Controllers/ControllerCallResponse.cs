using System.Runtime.Serialization;
using DanM.Core.Contracts.ControlDatas;

namespace DanM.Core.Contracts.Framework.Controllers;

[DataContract]
public class ControllerCallResponse
{
	[DataMember]
	public IControllerData ContentData { get; set; }
}