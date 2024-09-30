using System.Runtime.Serialization;
using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Contracts.Framework.Navigation;

namespace DanM.HrSystem.Contracts.Framework.Controllers;

[DataContract]
public class ControllerCallRequest
{
	[DataMember]
	public bool IsPostback { get; set; }
	[DataMember]
	public IControllerData ContentData { get; set; }
	[DataMember]
	public string ContentDataTypeName { get; set; }
	[DataMember]
	public NavigationQuery Navigation { get; set; } = new NavigationQuery();
}