using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface InformationApiMask_I
    {

        SemanticTypeInformation CreateTypeInformation(InfrastructureRuntimicModelMask_I model, System.Type inputType);
        SemanticTypeInformation CreateTypeInformation(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);
    }
}
