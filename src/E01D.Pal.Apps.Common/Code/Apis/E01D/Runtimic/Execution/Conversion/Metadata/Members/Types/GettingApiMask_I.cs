using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface GettingApiMask_I
    {
        

        ConvertedType_I Get(ILConversion conversion, SemanticModuleMask_I module, TypeReference input);

        //bool TryGet(SemanticModelMask_I model, TypeReference input, out SemanticTypeMask_I boundTypeMask);
        //bool TryGet(SemanticModelMask_I model, Type input, out SemanticTypeMask_I boundTypeMask);
    }
}
