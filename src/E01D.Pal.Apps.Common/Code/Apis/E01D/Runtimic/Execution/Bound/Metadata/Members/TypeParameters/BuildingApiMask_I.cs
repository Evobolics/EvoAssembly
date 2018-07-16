using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters
{
	public interface BuildingApiMask_I
	{
		void EnsureTypeParametersIfAny(BoundRuntimicModelMask_I conversion, BoundTypeDefinition converted);
	}
}
