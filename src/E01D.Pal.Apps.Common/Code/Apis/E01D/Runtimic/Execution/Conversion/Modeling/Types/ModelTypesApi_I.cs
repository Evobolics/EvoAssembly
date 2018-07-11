using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types
{
    public interface ModelTypesApi_I<TContainer> : ModelTypesApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
