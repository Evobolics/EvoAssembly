using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Creation
{
    public interface CreationApiMask_I
    {
        DefinitionApiMask_I Definitions { get; }

        GenericApiMask_I Generics { get; }

        ReferenceApiMask_I References { get; }


        BoundTypeDefinition Create(InfrastructureModelMask_I model, ModuleDefinition sourceModule, BoundModule_I semanticModule, System.Type type);

        BoundTypeDefinition Create(InfrastructureModelMask_I model, ModuleDefinition sourceModule, BoundModule_I semanticModule, TypeReference typeReference, System.Type underlyingType);
    }
}
