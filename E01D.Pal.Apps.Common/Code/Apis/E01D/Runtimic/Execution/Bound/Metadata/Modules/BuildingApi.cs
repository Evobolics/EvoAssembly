using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
    public class BuildingApi<TContainer> : BindingApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void BuildOut(InfrastructureModelMask_I semanticModel, SemanticModuleMask_I moduleEntry)
        {


            // If the module is bound, then build it out with bound types.
            if (moduleEntry.IsBound())
            {
                BuildOut(semanticModel, (BoundModule_I)moduleEntry);
            }
            // If the module is semantic, then build it out with semantic types.
            else if (moduleEntry.IsSemantic())
            {
                var semanticModule = (SemanticModule_I)moduleEntry;
                
                Semantic.Metadata.Members.Types.Ensuring.EnsureTypes(semanticModel, semanticModule);
            }
        }

        public void BuildOut(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule)
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
