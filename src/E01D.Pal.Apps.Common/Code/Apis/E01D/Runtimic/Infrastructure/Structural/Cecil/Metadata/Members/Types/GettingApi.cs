using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class GettingApi<TContainer> : CecilApiNode<TContainer>, GettingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeDefinition GetDefinition(InfrastructureModelMask_I model, TypeReference typeReference)
		{
			typeReference = Types.Ensuring.EnsureInternalTypeReference(model, typeReference);

			if (typeReference.IsDefinition)
			{
				return (TypeDefinition)typeReference;
			}
			else if (typeReference.IsGenericInstance)
			{
				var genericReference = (GenericInstanceType)typeReference;

				return GetDefinition(model, genericReference.ElementType);
			}


			throw new System.Exception("Not Supported");
		}


	}
}
