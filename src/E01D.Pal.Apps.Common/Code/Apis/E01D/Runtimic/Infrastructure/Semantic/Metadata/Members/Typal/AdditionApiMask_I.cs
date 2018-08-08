using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface AdditionApiMask_I
    {
        T Add<T>(Dictionary<string, T> dictionary, T entry)
            where T : TypeMask_I;

        Dictionary<string, T> Add<T>(Dictionary<string, T> results, Dictionary<string, T> dependencies)
            where T : TypeMask_I;

        SemanticTypeMask_I Add(RuntimicSystemModel model, SemanticModuleMask_I module, SemanticTypeDefinitionMask_I entry);
    }
}
