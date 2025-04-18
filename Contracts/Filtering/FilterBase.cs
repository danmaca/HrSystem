using System.Runtime.Serialization;
using DanM.Core.Primitives.Common;
using ProtoBuf;

namespace DanM.Core.Contracts.Filtering;

[DataContract]
[ProtoContract]
public class FilterBase : IFilterBase
{
	[DataMember]
	[ProtoMember(1)]
	public FilterPaging Paging { get; set; } = new FilterPaging();
}

public interface IFilterBase : IBindableEntity
{
	FilterPaging Paging { get; }
}