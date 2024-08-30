using Havit.Data.EntityFrameworkCore.Patterns.QueryServices;
using DanM.HrSystem.Contracts;

namespace DanM.HrSystem.DataLayer;

public static class DataFragmentExtensions
{
	public static DataFragmentResult<TItem> ToDataFragmentResult<TItem>(this DataFragment<TItem> source)
	{
		return new DataFragmentResult<TItem>
		{
			Data = source.Data,
			TotalCount = source.TotalCount
		};
	}
}