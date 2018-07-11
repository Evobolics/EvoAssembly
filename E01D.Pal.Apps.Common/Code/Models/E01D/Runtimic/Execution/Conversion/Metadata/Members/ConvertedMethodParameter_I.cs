using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedMethodParameter_I: ConvertedMethodParameterMask_I
    {
        new ParameterBuilder Builder { get; set; }

        new string Name { get; set; }

        

        new ParameterDefinition ParameterDefinition { get; set; }

        new SemanticTypeDefinitionMask_I ParameterType { get; set; }

        new int Position { get; set; }

        
    }
}
