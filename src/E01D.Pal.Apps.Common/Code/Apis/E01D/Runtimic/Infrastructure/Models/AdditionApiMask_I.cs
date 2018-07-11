using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Models
{
    public interface AdditionApiMask_I
    {
        void Add(SemanticModelMask_I model, SemanticTypeDefinitionMask_I semanticTypeDefinition);
    }
}
