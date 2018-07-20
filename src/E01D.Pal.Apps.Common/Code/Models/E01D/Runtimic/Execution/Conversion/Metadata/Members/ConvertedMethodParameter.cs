using System.Reflection.Emit;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedMethodParameter: ConvertedMethodParameter_I
    {
        public ParameterBuilder Builder { get; set; }

        public string Name { get; set; }

        public ParameterDefinition ParameterDefinition { get; set; }

        public SemanticTypeDefinitionMask_I ParameterType { get; set; }

        public int Position { get; set; }

        
    }
}
