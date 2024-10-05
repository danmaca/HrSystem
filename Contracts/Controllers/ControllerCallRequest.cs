using System.Runtime.Serialization;
using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Navigation;

namespace DanM.Core.Contracts.Controllers;

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