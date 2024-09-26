using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.Framework.Communication;
using DanM.HrSystem.Contracts.Framework.Controllers;
using DanM.HrSystem.Facades.Framework.Controllers;
using DanM.HrSystem.Primitives.Utils;
using Havit.Extensions.DependencyInjection.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DanM.HrSystem.Facades.Framework.Communication;

[Service]
[Authorize]
public class ClientServerCommunicator : IClientServerCommunicator
{
	private readonly IServiceProvider _serviceProvider;

	public ClientServerCommunicator(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task<Dto<string>> CallControllerSerialized(Dto<string> jsonRequest, CancellationToken cancellationToken = default)
	{
		ControllerCallRequest request;
		{
			var serializer = new DataContractSerialization(DataContractSerialization.SerializationMethod.Json);
			request = serializer.Deserialize<ControllerCallRequest>(jsonRequest.Value, DataContractSerialization.TypeKind.Controller);
		}

		string controllerTypeName = NameConventionResolver.TranslateDataToController(request.ContentDataTypeName);
		Type controllerType = this.GetType().Assembly.GetType(controllerTypeName);
		var controller = (IControllerBase)_serviceProvider.GetService(controllerType);

		var response = await controller.ProcessDataAsync(request, cancellationToken);

		{
			var serializer = new DataContractSerialization(DataContractSerialization.SerializationMethod.Json);
			return Dto.FromValue(serializer.SerializeToString(response, DataContractSerialization.TypeKind.Controller));
		}
	}
}