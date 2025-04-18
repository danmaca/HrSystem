using System.Runtime.Serialization;
using ProtoBuf;

namespace DanM.Core.Contracts.Collections;

[DataContract]
[ProtoContract]
public class ListSource<TItem> : List<TItem>
{
	[ProtoMember(1)]
	public int? TotalCount { get; set; }

	public ListSource()
	{
	}
	public ListSource(IEnumerable<TItem> source)
		: base(source)
	{
	}

	public ListSource<TResult> Transform<TResult>(Func<TItem, TResult> transformation)
	{
		var result = new ListSource<TResult>(this.Select(transformation));
		result.TotalCount = this.TotalCount;
		return result;
	}
}

public static class ListSourceExtensions
{
	public static ListSource<TItem> ToListSource<TItem>(this IQueryable<TItem> source, CancellationToken cancellationToken = default)
	{
		return new ListSource<TItem>(source);
	}

	public static async Task<ListSource<TItem>> ToListSourceAsync<TItem>(this IQueryable<TItem> source, CancellationToken cancellationToken = default)
	{
		var list = new ListSource<TItem>();

		list.TotalCount = source.Count();

      await foreach (var element in ((IAsyncEnumerable<TItem>)source).WithCancellation(cancellationToken))
         list.Add(element);
		return list;
	}
}