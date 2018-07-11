using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedGenericParameterTypeDefinitions: ConvertedGenericParameterTypeDefinitions_I
    {
        public GenericTypeParameterBuilder[] Builders { get; set; }

        public List<SemanticGenericParameterTypeDefinitionMask_I> All { get; set; } = new List<SemanticGenericParameterTypeDefinitionMask_I>();

        public Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I> ByName { get; set; } = new Dictionary<string, SemanticGenericParameterTypeDefinitionMask_I>();

        public Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I> ByPosition { get; set; } = new Dictionary<int, SemanticGenericParameterTypeDefinitionMask_I>();
    }
}
