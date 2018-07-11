using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances
{
	public interface Phase2DependencyBuildApiMask_I
	{
		void Build(ILConversion conversion, ConvertedGenericTypeDefinition_I convertedGeneric);
	}
}
