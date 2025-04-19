using DanM.Core.Contracts;
using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Filtering;
using DanM.HrSystem.Primitives.Utils;

namespace DanM.HrSystem.Contracts.Infrastructure;

public class LibraryInitialization
{
	public void InitLibrary()
	{
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(ControlData));
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(ControllerData));
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(FilterBase));
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(Dto));

		DataContractSerialization.ReadAssemblyContent(typeof(DanM.Core.Contracts.Properties.AssemblyInfo).Assembly);
		DataContractSerialization.ReadAssemblyContent(typeof(DanM.HrSystem.Contracts.Properties.AssemblyInfo).Assembly);
	}
}
