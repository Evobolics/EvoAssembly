using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Creation;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Ensuring;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
    public interface TypeApiMask_I
    {
        AdditionApiMask_I Addition { get; }

        BaseTypeApiMask_I BaseTypes { get; }

	    BuildingApiMask_I Building { get; }

		CreationApiMask_I Creation { get; }

        DefinitionApiMask_I Definitions { get; }

        DependencyApiMask_I Dependencies { get; }

        EnsuringApiMask_I Ensuring { get; }

	    GenericInstanceApiMask_I GenericInstances { get; }

		GettingApiMask_I Getting { get; }

        InterfaceApiMask_I Interfaces { get; }

        NamingApiMask_I Naming { get; }

        SimpleApiMask_I Simple { get; }

	    
	}
}
