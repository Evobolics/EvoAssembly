using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface FieldApiMask_I
    {
        SemanticFieldMask_I Get(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I declaringType,
            string fieldName);
    }
}
