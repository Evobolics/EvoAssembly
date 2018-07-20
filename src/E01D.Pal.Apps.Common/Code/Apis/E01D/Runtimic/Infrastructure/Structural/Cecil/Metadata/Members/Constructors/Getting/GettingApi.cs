using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting
{
	public class GettingApi<TContainer> : RuntimeApiNode<TContainer>, GettingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public FromConstructorInfoApi_I<TContainer> FromConstructorInfos { get; set; }


		FromConstructorInfoApiMask_I GettingApiMask_I.FromConstructorInfos => FromConstructorInfos;

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
