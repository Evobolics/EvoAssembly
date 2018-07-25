using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
    public interface ExecutionTypeDefinitionMask_I: SemanticTypeDefinitionMask_I
    {
        System.Type UnderlyingType { get; }
    }
}
