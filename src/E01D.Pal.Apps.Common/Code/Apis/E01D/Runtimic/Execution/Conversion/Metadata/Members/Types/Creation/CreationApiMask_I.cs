using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
    public interface CreationApiMask_I
    {

        //CecilApiMask_I Cecil { get; }
        DefinitionApiMask_I Definitions { get; }

        DotNetApiMask_I DotNet { get; }

        GenericApiMask_I Generics { get; }

        ReferenceApiMask_I References { get; }



        ConvertedTypeDefinition Create(BoundRuntimicModelMask_I semanticModel, System.Type type);

        ConvertedTypeDefinition Create(BoundRuntimicModelMask_I semanticModel,  TypeReference typeReference);
    }
}
