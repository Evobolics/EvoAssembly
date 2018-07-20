using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public interface GettingApi_I<TContainer> : GettingApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    //new FromMethodReferenceApi_I<TContainer> FromMethodReference { get; set; }
	}
}
