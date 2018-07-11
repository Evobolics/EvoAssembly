using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types
{
	public class ExternalApi<TContainer> : BindingApiNode<TContainer>, ExternalApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeReference Resolve(InfrastructureModelMask_I model, TypeReference elementType)
		{
			return Infrastructure.Models.Structural.Types.External.Resolve(model, elementType);
		}
	}
}
