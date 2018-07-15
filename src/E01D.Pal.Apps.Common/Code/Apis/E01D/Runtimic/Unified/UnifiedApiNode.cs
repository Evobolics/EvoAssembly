using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public class UnifiedApiNode<TContainer> : RuntimeApiNode<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public CecilApiMask_I Cecil => Container.Api.Runtimic.Infrastructure.Structural.Cecil;
	}
}
