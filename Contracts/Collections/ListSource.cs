using ProtoBuf;

namespace DanM.Core.Contracts.Collections;

[ProtoContract]
public class ListSource<TItem>
{
	[ProtoMember(1)]
	public List<TItem> Items { get; set; }
	[ProtoMember(2)]
	public int? TotalCount { get; set; }

	public ListSource()
	{
		this.Items = new List<TItem>();
	}
	public ListSource(IEnumerable<TItem> source)
	{
		this.Items = source.ToList();
	}

	public ListSource<TResult> Transform<TResult>(Func<TItem, TResult> transformation)
	{
		var result = new ListSource<TResult>(this.Items.Select(transformation));
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
         list.Items.Add(element);
		return list;
	}
}