using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.GenericInstances;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building
{
    public interface BuildingApiMask_I
    {
		ArrayApiMask_I Arrays { get; }

	    EnumApiMask_I Enums { get; }

	    GenericInstanceApiMask_I GenericInstances { get; }

	    GenericParameterApiMask_I GenericParameters { get; }

	    NonGenericInstanceApiMask_I NonGenericInstances { get; }


	    

	    void IfPossibleBuildPhase2(ILConversion conversion, ConvertedTypeDefinition_I converted);


	    void UpdateBuildPhase(ConvertedTypeDefinition_I converted, int newPhaseNumber);
    }
}
