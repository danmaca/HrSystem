using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.Core.Services.Controllers;

[Service]
public class ControllerServices : IControllerServices
{
	public IServiceProvider ServiceProvider { get; }

	public ControllerServices(IServiceProvider serviceProvider)
	{
	}

	public TService CreateScopeService<TService>() => this.ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<TService>();
}

public interface IControllerServices
{
	IServiceProvider ServiceProvider { get; }

	TService CreateScopeService<TService>();
}