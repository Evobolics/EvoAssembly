using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation
{
    public interface CreationApiMask_I
    {
        DefinitionApiMask_I Definitions { get; }

        GenericApiMask_I Generics { get; }

        ReferenceApiMask_I References { get; }


        BoundTypeDefinition Create(InfrastructureRuntimicModelMask_I model, System.Type type);

        BoundTypeDefinition Create(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, System.Type underlyingType);
    }
}
