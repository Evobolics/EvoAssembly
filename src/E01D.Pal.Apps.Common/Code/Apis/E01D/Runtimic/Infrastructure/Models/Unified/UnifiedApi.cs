using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Unified
{
	public class UnifiedApi<TContainer> : SemanticApiNode<TContainer>, UnifiedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public new UnifiedTypesApi_I<TContainer> Types { get; set; }




		UnifiedTypesApiMask_I UnifiedApiMask_I.Types => Types;
	}
}
