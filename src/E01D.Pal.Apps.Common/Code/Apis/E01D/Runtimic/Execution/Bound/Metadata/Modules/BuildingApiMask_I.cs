using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface BuildingApiMask_I
    {
	    //BoundModule Build(BoundRuntimicModelMask_I semanticModel, UnifiedModuleNode unifiedModuleNode);


		void BuildOut(RuntimicSystemModel semanticModel, SemanticModuleMask_I moduleEntry);

        void BuildOut(RuntimicSystemModel semanticModel, BoundModule_I boundModule);
    }
}
