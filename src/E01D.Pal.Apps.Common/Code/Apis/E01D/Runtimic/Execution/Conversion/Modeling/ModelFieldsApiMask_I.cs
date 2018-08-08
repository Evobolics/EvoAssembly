using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling
{
    public interface ModelFieldsApiMask_I
    {
        FieldInfo ResolveFieldReference(ILConversion conversion, ConvertedTypeDefinitionMask_I accessingType,
            BoundTypeDefinitionMask_I declaringFieldReferenceType, FieldReference fieldReference);
    }
}
