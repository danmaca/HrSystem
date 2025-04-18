using System.Runtime.Serialization;
using ProtoBuf;

namespace DanM.Core.Contracts.Filtering;

[DataContract]
[ProtoContract]
public class FilterPaging
{
	[DataMember]
	[ProtoMember(1)]
	public int StartRowIndex { get; set; }
	[DataMember]
	[ProtoMember(2)]
	public int? RowsCount { get; set; }
}