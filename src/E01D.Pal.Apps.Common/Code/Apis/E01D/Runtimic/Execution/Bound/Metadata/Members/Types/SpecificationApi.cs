using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class SpecificationApi<TContainer> : BoundApiNode<TContainer>, SpecificationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public SpecificationApi()
		{
			
		}
	}
}
