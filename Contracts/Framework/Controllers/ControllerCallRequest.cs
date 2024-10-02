using System.Runtime.Serialization;
using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Framework.Navigation;

namespace DanM.Core.Contracts.Framework.Controllers;

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