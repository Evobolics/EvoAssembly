using System;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building.NonGenericInstances
{
	public interface Phase1InitialBuildApiMask_I
	{
		BoundTypeDefinition Build(BoundRuntimicModelMask_I semanticModel, BoundTypeDefinition bound, Type underlyingType, BoundTypeDefinitionMask_I declaringType);
	}
}
