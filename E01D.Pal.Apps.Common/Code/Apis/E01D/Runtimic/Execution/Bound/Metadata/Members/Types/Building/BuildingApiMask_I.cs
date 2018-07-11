using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building.NonGenericInstances;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building
{
    public interface BuildingApiMask_I
    {
		ArrayApiMask_I Arrays { get; }

	    EnumApiMask_I Enums { get; }

	    GenericInstanceApiMask_I GenericInstances { get; }

	    GenericParameterApiMask_I GenericParameters { get; }

	    NonGenericInstanceApiMask_I NonGenericInstances { get; }

	}
}
