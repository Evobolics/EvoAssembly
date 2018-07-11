using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface AdditionApiMask_I
    {
        T Add<T>(Dictionary<string, T> results, T entry)
            where T : TypeMask_I;

        Dictionary<string, T> Add<T>(Dictionary<string, T> results, Dictionary<string, T> dependencies)
            where T : BoundTypeMask_I;

        SemanticTypeMask_I Add(ILConversion conversion, ConvertedModuleMask_I module, ConvertedTypeDefinition_I entry);
    }
}
