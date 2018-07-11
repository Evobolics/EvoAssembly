using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building
{
    public class EnumApi<TContainer> : ConversionApiNode<TContainer>, EnumApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
