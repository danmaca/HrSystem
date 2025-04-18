using DanM.Core.Contracts.Filtering;
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

	public static async Task<ListSource<TItem>> ToListSourceAsync<TItem>(this IQueryable<TItem> query, IFilterBase filter, CancellationToken cancellationToken = default)
	{
		var list = new ListSource<TItem>();

		list.TotalCount = query.Count();

		if (filter.Paging.RowsCount != null)
		{
			if (filter.Paging.StartRowIndex > 0)
				query = query.Skip(filter.Paging.StartRowIndex);
			query = query.Take(filter.Paging.RowsCount.Value);
		}

      await foreach (var element in ((IAsyncEnumerable<TItem>)query).WithCancellation(cancellationToken))
         list.Items.Add(element);
		return list;
	}
}