using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public interface EnsuringApiMask_I
    {
	    //ArrayApiMask_I Arrays { get; }

	    EnumApiMask_I Enums { get; }

	    //GatheringApiMask_I Gathering { get; }

	    GenericInstanceApiMask_I GenericInstances { get; }

	    GenericParameterApiMask_I GenericParameters { get; }

	    NonGenericInstanceApiMask_I NonGenericInstances { get; }

	    //PointerApiMask_I Pointers { get; }

	    RequiredModifierApiMask_I RequiredModifiers { get; }

	    

	    



		/// <summary>
		/// Ensures the type is part of the module.
		/// </summary>
		SemanticTypeDefinitionMask_I Ensure(RuntimicSystemModel semanticModel, ExecutionEnsureContext context);

	    

		void EnsureTypes(RuntimicSystemModel semanticModel, BoundModule_I boundModule);

	    



    }
}
