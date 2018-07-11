using System;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class EnsuringApi<TContainer> : CecilApiNode<TContainer>, EnsuringApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeReference EnsureInternalTypeReference(InfrastructureModelMask_I model, TypeReference typeReference)
		{
			if (!Types.IsExternal(typeReference)) return typeReference;
			
			return ResolveExternalTypeReference(model, typeReference);	
		}

		public TypeReference ResolveExternalTypeReference(InfrastructureModelMask_I model, TypeReference externalReference)
		{
			var storedReference = Infrastructure.Models.Structural.Types.Collection.GetStoredTypeReference(model, externalReference);

			if (storedReference != null) return storedReference;

			throw new System.Exception("Could not resolve external reference.");
		}

		public TypeReference EnsureInternalTypeReference(InfrastructureModelMask_I model, Type input)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			TypeReference typeDefinition = Infrastructure.Models.Structural.Types.Collection.GetStoredTypeReference(model, resolutionName);

			if (typeDefinition != null) return typeDefinition;

			if (!input.IsGenericType)
			{
				throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
			}

			var genericArguments = input.GenericTypeArguments;

			if (genericArguments.Length < 1)
			{
				throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
			}

			var genericTypeDefinition = input.GetGenericTypeDefinition();

			var genericTypeDefinition1 = EnsureInternalTypeReference(model, genericTypeDefinition);

			var genericArgumentReferences = new TypeReference[genericArguments.Length];

			for (int i = 0; i < genericArguments.Length; i++)
			{
				genericArgumentReferences[i] = EnsureInternalTypeReference(model, genericArguments[i]);
			}

			var result = genericTypeDefinition1.MakeGenericInstanceType(genericArgumentReferences);

			return result;
		}
	}
}
