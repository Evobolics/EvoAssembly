using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
    public interface BuildingApiMask_I
    {
        void BuildOut(InfrastructureModelMask_I semanticModel, SemanticModuleMask_I moduleEntry);

        void BuildOut(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule);
    }
}
