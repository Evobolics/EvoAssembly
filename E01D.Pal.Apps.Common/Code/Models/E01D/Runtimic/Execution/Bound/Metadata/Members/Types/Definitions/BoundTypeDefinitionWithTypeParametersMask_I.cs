using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundTypeDefinitionWithTypeParametersMask_I: SemanticTypeDefinitionWithTypeParametersMask_I
    {
        new BoundGenericParameterTypeDefinitionsMask_I TypeParameters { get; }
    }
}
