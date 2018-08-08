using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public class GettingApi<TContainer> : CecilApiNode<TContainer>, GettingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

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

		public MethodDefinition GetMethodDefinition(RuntimicSystemModel model, Collection<MethodDefinition> methodDefinitions, int metadataToken)
		{
			

			for (int i = 0; i < methodDefinitions.Count; i++)
			{
				var methodDefinition = methodDefinitions[i];

				if (metadataToken == methodDefinition.MetadataToken.ToInt32()) return methodDefinition;
			}

			throw new Exception($"Could not find a method matching the method with the metadata token {metadataToken}.");
		}

	
		
		public MethodReference GetMethodReference(RuntimicSystemModel model, Collection<MethodDefinition> methods, Type memberDeclaringType, int methodMetadataToken)
		{
			if (memberDeclaringType.Module.Assembly.IsDynamic)
				throw new Exception("Cannot be used for methods that orginate from dynamic assemblies as the metadata tokens will not match.");

			//  DEBUGGING: This is the current issue
			var methodDefinition = GetMethodDefinition(model, methods, methodMetadataToken);

			Type[] typeArguments = memberDeclaringType.GenericTypeArguments;

			if (typeArguments == null || typeArguments.Length < 1) return methodDefinition;

			return Methods.Building.MethodDefinitions.MakeGenericInstanceTypeMethodReference(model, methodDefinition, memberDeclaringType, typeArguments);
		}
	}
}
