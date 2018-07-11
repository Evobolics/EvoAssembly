using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedGenericParameterTypeDefinitions_I: ConvertedGenericParameterTypeDefinitionsMask_I
    {
        new GenericTypeParameterBuilder[] Builders { get; set; }

        new List<SemanticGenericParameterTypeDefinitionMask_I> All { get; set; } 

        new Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I> ByName { get; set; }

        new Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I> ByPosition { get; set; }
    }
}
