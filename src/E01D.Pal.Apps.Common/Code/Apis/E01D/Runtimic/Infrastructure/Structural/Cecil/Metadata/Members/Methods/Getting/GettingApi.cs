using Mono.Cecil;
using Mono.Collections.Generic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting.FromMethodInfo;
using Root.Code.Containers.E01D.Runtimic;


namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting
{
	public class GettingApi<TContainer> : RuntimeApiNode<TContainer>, GettingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public FromMethodInfoApi_I<TContainer> FromMethodInfos { get; set; }


		FromMethodInfoApiMask_I GettingApiMask_I.FromMethodInfos => FromMethodInfos;

		public Collection<MethodDefinition> GetDefinitions(TypeReference inputSourceTypeReference)
		{
			if (inputSourceTypeReference.IsDefinition)
			{
				return ((TypeDefinition)inputSourceTypeReference).Methods;
			}
			else if (inputSourceTypeReference.IsGenericInstance)
			{
				var x = (GenericInstanceType)inputSourceTypeReference;
				var internalOrExternalReference = x.ElementType;
				var typeDefinition = (TypeDefinition)internalOrExternalReference;
				return typeDefinition.Methods;
			}
			else
			{
				throw new System.NotSupportedException($"Getting method definititions for a {inputSourceTypeReference.GetType().FullName} is not supported yet.");
			}
		}
	}
}
