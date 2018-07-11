using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface TypeApi_I<TContainer> : TypeApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        new CreationApi_I<TContainer> Creation { get; set; }

	    new GenericInstanceApi_I<TContainer> GenericInstances { get; }

		new InformationApi_I<TContainer> Information { get; set; }
    }
}
