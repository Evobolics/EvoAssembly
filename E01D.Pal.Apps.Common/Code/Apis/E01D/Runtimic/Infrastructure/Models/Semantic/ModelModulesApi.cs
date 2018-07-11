using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
    public class ModelModulesApi<TContainer> : ConversionApiNode<TContainer>, ModelModulesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
