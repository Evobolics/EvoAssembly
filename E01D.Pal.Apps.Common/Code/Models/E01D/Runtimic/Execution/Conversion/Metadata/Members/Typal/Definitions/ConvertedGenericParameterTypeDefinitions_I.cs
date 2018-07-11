using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedGenericParameterTypeDefinitions_I: ConvertedGenericParameterTypeDefinitionsMask_I
    {
        new GenericTypeParameterBuilder[] Builders { get; set; }

        new List<SemanticParameterTypeDefinitionMask_I> All { get; set; } 

        new Dictionary<string, SemanticParameterTypeDefinitionMask_I> ByName { get; set; }

        new Dictionary<int, SemanticParameterTypeDefinitionMask_I> ByPosition { get; set; }
    }
}
