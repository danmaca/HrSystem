using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Primitives.Utils;

namespace DanM.HrSystem.Contracts.Infrastructure;

public class LibraryInitialization
{
	public void InitLibrary()
	{
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(ControlData));
		DataContractSerialization.RegisterKnownTypesBase(DataContractSerialization.TypeKind.Controller, typeof(ControllerData));

		DataContractSerialization.ReadAssemblyContent(this.GetType().Assembly);
	}
}
