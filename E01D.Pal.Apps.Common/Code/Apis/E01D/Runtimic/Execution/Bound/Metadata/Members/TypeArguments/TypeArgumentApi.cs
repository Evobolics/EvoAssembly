using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.TypeArguments
{
	public class TypeArgumentApi<TContainer> : BindingApiNode<TContainer>, TypeArgumentApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		public BuildingApi_I<TContainer> Building { get; set; }

		BuildingApiMask_I TypeArgumentApiMask_I.Building => Building;
	}
}
