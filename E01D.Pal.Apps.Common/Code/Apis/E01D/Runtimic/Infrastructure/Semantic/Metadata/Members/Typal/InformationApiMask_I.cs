using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface InformationApiMask_I
    {

        SemanticTypeInformation CreateTypeInformation(InfrastructureModelMask_I model, System.Type inputType);
        SemanticTypeInformation CreateTypeInformation(InfrastructureModelMask_I model, TypeReference typeReference);
    }
}
