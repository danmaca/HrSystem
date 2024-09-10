using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DanM.HrSystem.Services.Framework.Descriptors;

[Service(Lifetime = ServiceLifetime.Singleton)]
public class ModelDescriptor : IModelDescriptor
{

}

public interface IModelDescriptor
{
}