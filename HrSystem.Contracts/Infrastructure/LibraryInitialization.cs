﻿using DanM.Core.Contracts.ControlDatas;
using DanM.HrSystem.Primitives.Utils;

namespace DanM.HrSystem.Contracts.Infrastructure;

public class LibraryInitialization
{
	public void InitLibrary()
	{
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(ControlData));
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(ControllerData));

		DataContractSerialization.ReadAssemblyContent(typeof(DanM.Core.Contracts.Properties.AssemblyInfo).Assembly);
		DataContractSerialization.ReadAssemblyContent(typeof(DanM.HrSystem.Contracts.Properties.AssemblyInfo).Assembly);
	}
}
