using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters
{
	public interface BuildingApiMask_I
	{
		void EnsureTypeParametersIfAny(InfrastructureModelMask_I conversion, BoundTypeDefinition converted);
	}
}
