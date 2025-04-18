using System.Runtime.Serialization;
using DanM.Core.Primitives.Common;

namespace DanM.Core.Contracts.Filtering;

[DataContract]
public class FilterBase : IFilterBase
{
	[DataMember]
	public FilterPaging Paging { get; set; } = new FilterPaging();
	[DataMember]
	public int PagingStartRowIndex { get; set; }
	[DataMember]
	public int? PagingRowsCount { get; set; }
}

public interface IFilterBase : IBindableEntity
{
	//FilterPaging Paging { get; }
	int PagingStartRowIndex { get; set; }
	int? PagingRowsCount { get; set; }
}