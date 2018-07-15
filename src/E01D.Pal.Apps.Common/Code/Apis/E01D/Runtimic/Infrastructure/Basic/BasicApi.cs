using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Basic
{
	public class BasicApi<TContainer> : SemanticApiNode<TContainer>, BasicApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public new BasicTypesApi_I<TContainer> Types { get; set; }




		BasicTypesApiMask_I BasicApiMask_I.Types => Types;
	}
}
