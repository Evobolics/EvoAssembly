using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Modules
{
    public class BuildingApi<TContainer> : SemanticApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
       

        public void BuildOut(RuntimicSystemModel semanticModel, SemanticModule_I boundModule)
        {
            // If all the types have already been ensured, then no need to do anything else.
            if (boundModule.IsBuiltOut)
            {
                return;
            }

            boundModule.IsBuiltOut = true;

            Types.Ensuring.EnsureTypes(semanticModel, boundModule);
        }
    }
}
