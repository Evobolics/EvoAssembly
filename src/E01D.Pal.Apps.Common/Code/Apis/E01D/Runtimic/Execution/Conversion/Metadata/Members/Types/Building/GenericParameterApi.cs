using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building
{
    public class GenericParameterApi<TContainer> : ConversionApiNode<TContainer>, GenericParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        
    }
}
