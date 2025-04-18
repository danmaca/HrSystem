using System.Runtime.Serialization;

namespace DanM.Core.Contracts.Filtering;

[DataContract]
public class FilterPaging
{
	[DataMember]
	public int StartRowIndex { get; set; }
	[DataMember]
	public int? RowsCount { get; set; }
}