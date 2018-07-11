using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding
{
    public interface BindingApi_I<TContainer> : BindingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new MetadataApi_I<TContainer> Metadata { get; set; }

        new ModelApi_I<TContainer> Models { get; set; }
    }
}
