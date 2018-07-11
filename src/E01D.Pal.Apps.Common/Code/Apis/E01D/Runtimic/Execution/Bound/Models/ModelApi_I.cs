using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
    public interface ModelApi_I<TContainer>: ModelApiMask_I
        where TContainer:RuntimicContainer_I<TContainer>
    {
        new ModelTypesApi_I<TContainer> Types { get; set; }

        new ModelModulesApi_I<TContainer> Modules { get; set; }
    }
}
