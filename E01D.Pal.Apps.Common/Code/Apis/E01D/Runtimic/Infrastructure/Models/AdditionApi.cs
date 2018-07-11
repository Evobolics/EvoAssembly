using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Models
{
    public class AdditionApi<TContainer> : SemanticApiNode<TContainer>, AdditionApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void Add(SemanticModelMask_I model, SemanticTypeDefinitionMask_I semanticTypeDefinition)
        {
            if (semanticTypeDefinition.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.SimpleClass")
            {
                
            }

            model.Types.ByResolutionName.Add(semanticTypeDefinition.FullName, semanticTypeDefinition);
        }
    }
}
