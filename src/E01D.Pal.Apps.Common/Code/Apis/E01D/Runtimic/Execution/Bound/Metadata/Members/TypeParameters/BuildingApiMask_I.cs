using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters
{
	public interface BuildingApiMask_I
	{
		void EnsureTypeParametersIfAny(RuntimicSystemModel conversion, BoundTypeDefinition converted);
	}
}
