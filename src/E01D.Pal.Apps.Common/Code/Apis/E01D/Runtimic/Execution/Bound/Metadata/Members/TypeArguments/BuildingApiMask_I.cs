using System;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeArguments
{
	public interface BuildingApiMask_I
	{
		Type[] Build(InfrastructureRuntimicModelMask_I semanticModel, BoundTypeDefinition boundInput, System.Type type);
	}
}
