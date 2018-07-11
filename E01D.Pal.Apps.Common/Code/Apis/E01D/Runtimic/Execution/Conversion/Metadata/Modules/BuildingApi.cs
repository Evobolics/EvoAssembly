using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public class BuildingApi<TContainer> : SemanticApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void BuildOut(ILConversion conversion, SemanticModuleMask_I boundModule)
        {
            var semanticModel = conversion.Model;

            if (!boundModule.IsConverted())
            {
                Binding.Metadata.Modules.Building.BuildOut(semanticModel, boundModule);
            }

            // If all the types have already been ensured, then no need to do anything else.
            if (boundModule.IsBuiltOut)
            {
                return;
            }

            var converted = (ConvertedModule_I) boundModule;

            converted.IsBuiltOut = true;

            Types.Ensuring.EnsureTypes(semanticModel, boundModule);
        }
    }
}
