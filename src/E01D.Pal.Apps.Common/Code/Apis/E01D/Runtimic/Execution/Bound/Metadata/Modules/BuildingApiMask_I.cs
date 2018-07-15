using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface BuildingApiMask_I
    {
	    BoundModule Build(InfrastructureRuntimicModelMask_I semanticModel, UnifiedModuleNode unifiedModuleNode);


		void BuildOut(InfrastructureRuntimicModelMask_I semanticModel, SemanticModuleMask_I moduleEntry);

        void BuildOut(InfrastructureRuntimicModelMask_I semanticModel, BoundModule_I boundModule);
    }
}
