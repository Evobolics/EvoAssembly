using System;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeArguments
{
	public interface BuildingApiMask_I
	{
		Type[] Build(InfrastructureModelMask_I semanticModel, BoundTypeDefinition boundInput, System.Type type);
	}
}
