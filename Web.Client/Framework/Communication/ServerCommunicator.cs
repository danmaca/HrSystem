﻿using DanM.HrSystem.Contracts;
using DanM.HrSystem.Contracts.Framework.Communication;
using DanM.HrSystem.Contracts.Framework.Controllers;
using DanM.HrSystem.Primitives.Utils;

namespace DanM.HrSystem.Web.Client.Framework.Communication;

public class ServerCommunicator : IServerCommunicator
{
	private readonly IClientServerCommunicator _clientServerCommunicator;

	public ServerCommunicator(IClientServerCommunicator clientServerCommunicator)
	{
		_clientServerCommunicator = clientServerCommunicator;
	}

	public async Task<ControllerCallResponse> CallController(ControllerCallRequest request, CancellationToken cancellationToken = default)
	{
		var serializer = new DataContractSerialization(DataContractSerialization.SerializationMethod.Json);

		string jsonRequest = serializer.SerializeToString(request, DataContractSerialization.TypeKind.Controller);

		var jsonResponse = await _clientServerCommunicator.CallControllerSerialized(Dto.FromValue(jsonRequest));

		var response = serializer.Deserialize<ControllerCallResponse>(jsonResponse.Value, DataContractSerialization.TypeKind.Controller);
		return response;
	}
}

public interface IServerCommunicator
{
	Task<ControllerCallResponse> CallController(ControllerCallRequest request, CancellationToken cancellationToken = default);
}