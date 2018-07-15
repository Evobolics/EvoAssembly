using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface BaseTypeApiMask_I
    {
        SemanticTypeMask_I GetBaseType(InfrastructureRuntimicModelMask_I semanticModel, BoundModule_I moduleEntry, TypeDefinition typeDefinition);
    }
}
