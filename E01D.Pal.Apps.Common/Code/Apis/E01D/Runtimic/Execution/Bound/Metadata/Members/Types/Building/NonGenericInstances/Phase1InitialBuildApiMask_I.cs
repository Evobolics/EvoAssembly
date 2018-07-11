using System;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building.NonGenericInstances
{
	public interface Phase1InitialBuildApiMask_I
	{
		BoundTypeDefinition Build(InfrastructureModelMask_I semanticModel, BoundTypeDefinition bound, Type underlyingType, BoundTypeDefinitionMask_I declaringType);
	}
}
