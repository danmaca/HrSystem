using DanM.Core.Contracts.ControlDatas;
using DanM.HrSystem.Model.Framework;
using Havit.Data.Patterns.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Services.Controllers;

public abstract class EntityDetailControllerBase<TEntity, TRepository, TData> : DetailControllerBase<TEntity, TData>
	where TEntity : class, IEntity, new()
	where TRepository : IRepository<TEntity>
	where TData : DetailControllerData
{
	private TRepository _entityRepository;

	protected EntityDetailControllerBase(
		IDetailControllerServices services)
		: base(services)
	{
		_entityRepository = services.ServiceProvider.GetRequiredService<TRepository>();
	}

	protected override async Task<TEntity> OnLoadEntityAsync()
	{
		return await _entityRepository.GetObjectAsync(this.Data.Setup.EntityId.Value);
	}

	protected override void ClearEntityCache()
	{
		base.ClearEntityCache();

		_entityRepository = this.Services.CreateScopeService<TRepository>();
	}
}