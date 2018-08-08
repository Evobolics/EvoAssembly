using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Configurational
{
    public interface ConfigurationalApi_I<TContainer> : ConfigurationalApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
