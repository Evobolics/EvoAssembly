using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Ensuring
{
    public class EnumApi<TContainer> : ConversionApiNode<TContainer>, EnumApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
