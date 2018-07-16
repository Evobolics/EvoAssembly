using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class InstructionApi<TContainer> : BoundApiNode<TContainer>, InstructionApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	}
}
