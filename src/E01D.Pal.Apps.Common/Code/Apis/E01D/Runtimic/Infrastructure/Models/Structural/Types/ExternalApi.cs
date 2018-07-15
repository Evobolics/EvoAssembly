using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
	public class ExternalApi<TContainer> : SemanticApiNode<TContainer>, ExternalApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeReference Resolve(InfrastructureRuntimicModelMask_I model, TypeReference externalReference)
		{
			var storedReference = Cecil.Types.Getting.GetStoredTypeReference(model, externalReference);

			if (storedReference != null) return storedReference;

			throw new System.Exception("Could not resolve external reference.");
		}
	}
}
