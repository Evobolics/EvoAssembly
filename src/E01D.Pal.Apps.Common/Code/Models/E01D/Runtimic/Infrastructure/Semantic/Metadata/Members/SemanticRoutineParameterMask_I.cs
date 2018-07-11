using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface SemanticRoutineParameterMask_I
    {
        string Name { get; }

        ParameterDefinition ParameterDefinition { get; }

        SemanticTypeDefinitionMask_I ParameterType { get; }

        int Position { get; }
    }
}
