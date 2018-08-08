using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation
{
    public interface CreationApiMask_I
    {
        DefinitionApiMask_I Definitions { get; }

        GenericApiMask_I Generics { get; }

        ReferenceApiMask_I References { get; }


        BoundTypeDefinition Create(RuntimicSystemModel model, System.Type type);

        BoundTypeDefinition Create(RuntimicSystemModel model, TypeReference typeReference, System.Type underlyingType);
    }
}
