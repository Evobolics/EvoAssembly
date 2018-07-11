using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering
{
    public interface GatheringApiMask_I
    {
        CecilApiMask_I Cecil { get; }

        BoundTypeDefinitionMask_I EnsureBaseType(ILConversion conversion, ConvertedTypeDefinition_I converted);

        

        void EnsureInterfaces(ILConversion conversion, ConvertedTypeDefinition_I converted);

        

        void GetNestedTypes(ILConversion conversion, ConvertedTypeDefinition_I declaringType);

        

        
    }
}
