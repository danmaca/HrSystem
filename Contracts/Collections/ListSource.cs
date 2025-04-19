using DanM.Core.Contracts.Filtering;
using ProtoBuf;

namespace DanM.Core.Contracts.Collections;

[ProtoContract]
public class ListSource<TItem> : IListSource
{
	[ProtoMember(1)]
	public List<TItem> Items { get; set; }
	[ProtoMember(2)]
	public int? TotalCount { get; set; }

	IEnumerable<object> IListSource.Items => this.Items.Cast<object>();

	public ListSource()
	{
		this.Items = new List<TItem>();
	}
	public ListSource(IEnumerable<TItem> source)
	{
		this.Items = source.ToList();
	}
	public ListSource(IEnumerable<TItem> source, int? totalCount)
		: this(source)
	{
		this.TotalCount = totalCount;
	}

	public ListSource<TResult> Transform<TResult>(Func<TItem, TResult> transformation)
	{
		var result = new ListSource<TResult>(this.Items.Select(transformation));
		result.TotalCount = this.TotalCount;
		return result;
	}
}

public interface IListSource
{
	IEnumerable<object> Items { get; }
	int? TotalCount { get; set; }
}

public static class ListSourceExtensions
{
	public static ListSource<TItem> ToListSource<TItem>(this IQueryable<TItem> query, IFilterBase filter, CancellationToken cancellationToken = default)
	{
		var list = PrepareListSource(ref query, filter);
		list.Items.AddRange(query);
		return list;
	}

	public static async Task<ListSource<TItem>> ToListSourceAsync<TItem>(this IQueryable<TItem> query, IFilterBase filter, CancellationToken cancellationToken = default)
	{
		var list = PrepareListSource(ref query, filter);

		await foreach (var element in ((IAsyncEnumerable<TItem>)query).WithCancellation(cancellationToken))
			list.Items.Add(element);
		return list;
	}

	private static ListSource<TItem> PrepareListSource<TItem>(ref IQueryable<TItem> query, IFilterBase filter)
	{
		var list = new ListSource<TItem>();

		list.TotalCount = query.Count();

		if (filter.Paging.RowsCount != null)
		{
			if (filter.Paging.StartRowIndex > 0)
				query = query.Skip(filter.Paging.StartRowIndex);
			query = query.Take(filter.Paging.RowsCount.Value);
		}

		return list;
	}
}