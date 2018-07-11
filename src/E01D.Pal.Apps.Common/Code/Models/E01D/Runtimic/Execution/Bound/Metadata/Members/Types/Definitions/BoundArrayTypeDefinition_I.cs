using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundArrayTypeDefinition_I : BoundTypeDefinition_I, BoundArrayTypeDefinitionMask_I, BoundTypeDefinitionWithMethodsMask_I
	{
        new SemanticTypeDefinitionMask_I ElementType { get; set; }
    }
}
