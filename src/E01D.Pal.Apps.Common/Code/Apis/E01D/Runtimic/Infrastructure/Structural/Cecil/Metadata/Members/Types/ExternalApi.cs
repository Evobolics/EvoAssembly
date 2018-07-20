using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class ExternalApi<TContainer> : CecilApiNode<TContainer>, ExternalApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeReference Resolve(StructuralRuntimicModelMask_I model, TypeReference externalReference)
		{
			var storedReference = Types.Getting.GetStoredTypeReference(model, externalReference);

			if (storedReference != null) return storedReference;

			throw new System.Exception("Could not resolve external reference.");
		}
	}
}
