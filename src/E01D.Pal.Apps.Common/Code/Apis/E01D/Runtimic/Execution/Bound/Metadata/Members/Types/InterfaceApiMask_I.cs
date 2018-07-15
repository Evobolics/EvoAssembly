using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
    public interface InterfaceApiMask_I
    {
        BoundTypeDefinitionInterfaces GetInterfaces(InfrastructureRuntimicModelMask_I semanticModel, TypeDefinition typeDefinition);
    }
}
