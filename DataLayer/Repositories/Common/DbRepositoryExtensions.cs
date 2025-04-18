using System.Reflection;
using DanM.Core.Contracts.Filtering;
using Havit.Data.EntityFrameworkCore.Patterns.Repositories;

namespace DanM.HrSystem.DataLayer.Repositories.Common;

public static class DbRepositoryExtensions
{
	public static IQueryable<TEntity> GetData<TEntity>(this DbRepository<TEntity> repository, IFilterBase filter)
		where TEntity : class
	{
		var dataProp = repository.GetType().GetProperty("Data", BindingFlags.NonPublic | BindingFlags.Instance);
		IQueryable<TEntity> query = (IQueryable<TEntity>)dataProp.GetValue(repository);
		return query;
	}
}
