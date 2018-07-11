using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.TypeParameters
{
    public interface TypeParameterApi_I<TContainer> : TypeParameterApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
    }
}
