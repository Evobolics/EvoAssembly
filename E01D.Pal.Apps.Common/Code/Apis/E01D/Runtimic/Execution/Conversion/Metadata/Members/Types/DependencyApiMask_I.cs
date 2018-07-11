using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface DependencyApiMask_I
    {
        List<SemanticTypeMask_I> Calculate(SemanticModuleMask_I convertedModule, List<SemanticTypeMask_I> list);

        void PutInDependencyOrder(List<SemanticTypeMask_I> list);
        void Add(SemanticTypeMask_I typeDefinitionEntry, SemanticTypeMask_I dependent);
    }
}
