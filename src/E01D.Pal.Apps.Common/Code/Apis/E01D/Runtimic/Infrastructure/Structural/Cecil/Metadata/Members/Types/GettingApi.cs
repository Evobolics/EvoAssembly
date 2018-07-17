using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class GettingApi<TContainer> : CecilApiNode<TContainer>, GettingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeDefinition GetDefinition(StructuralRuntimicModelMask_I model, TypeReference typeReference)
		{
			var typeReference1 = Types.Getting.GetInternalTypeReference(model, typeReference);

			if (typeReference1.IsDefinition)
			{
				return (TypeDefinition)typeReference1;
			}

			if (typeReference1.IsGenericInstance)
			{
				var genericReference = (GenericInstanceType)typeReference1;

				return GetDefinition(model, genericReference.ElementType);
			}

			var fullName = Types.Naming.GetResolutionName(typeReference1);

			var node = Unified.Types.Get(model, fullName);

			if (node.SourceTypeReference.IsDefinition)
			{
				return (TypeDefinition)node.SourceTypeReference;
			}

			throw new System.Exception("Could not locate a definition.");
		}

		public List<TypeDefinition> GetAllToList(AssemblyDefinition[] assemblies)
		{
			var typeList = new List<TypeDefinition>();

			for (int i = 0; i < assemblies.Length; i++)
			{
				var assembly = assemblies[i];

				for (int j = 0; j < assembly.Modules.Count; j++)
				{
					var module = assembly.Modules[j];

					foreach (var typeDefinition in module.GetAllTypes())
					{
						typeList.Add(typeDefinition);
					}
				}
			}

			return typeList;
		}

		public TypeDefinition[] GetAllToArray(AssemblyDefinition[] assemblies)
		{
			return GetAllToList(assemblies).ToArray();
		}

		

		public TypeDefinition GetTypeDefinition(AssemblyDefinition assemblyDefinition, string resolutionName)
		{
			for (int j = 0; j < assemblyDefinition.Modules.Count; j++)
			{
				var module = assemblyDefinition.Modules[j];

				foreach (var typeDefinition in module.GetTypes())
				{
					if (string.Compare(Types.Naming.GetResolutionName(typeDefinition), resolutionName, StringComparison.Ordinal) != 0)
					{
						continue;
					}

					return typeDefinition;
				}
			}

			return null;
		}

		//public TypeDefinition[] GetTypeDefinitions(InfrastructureRuntimicModelMask_I conversionModel, Type[] types)
		//{
		//	Dictionary<string, TypeDefinition> index = new Dictionary<string, TypeDefinition>();

		//	//for (int j = 0; j < assemblyDefinition.Modules.Count; j++)
		//	//{
		//	//	var module = assemblyDefinition.Modules[j];

		//	//	foreach (var typeDefinition in module.GetTypes())
		//	//	{
		//	//		if (string.Compare(Types.Naming.GetResolutionName(typeDefinition), resolutionName, StringComparison.Ordinal) != 0)
		//	//		{
		//	//			continue;
		//	//		}

		//	//		return typeDefinition;
		//	//	}
		//	//}
		//}

		public TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, TypeReference typeReference)
		{
			var resolutionName = Types.Naming.GetResolutionName(typeReference);

			return GetStoredTypeReference(model, resolutionName);
		}

		public TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, Type genericTypeDefinitionType)
		{
			var fullName = Types.Naming.GetResolutionName(genericTypeDefinitionType);

			return GetStoredTypeReference(model, fullName);
		}

		public TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, string fullName)
		{
			// Uses GetSemanticNode instead since this call can be made before the semantic type istself is created.
			// During semantic type creation, this call is made.
			var unifiedNode = Unified.Types.Get(model, fullName);

			return unifiedNode?.SourceTypeReference;
		}

		public TypeReference GetStoredTypeReference(StructuralRuntimicModelMask_I model, string fullName, out UnifiedTypeNode basicNode)
		{
			// Uses GetSemanticNode instead since this call can be made before the semantic type istself is created.
			// During semantic type creation, this call is made.
			basicNode = Unified.Types.Get(model, fullName);

			

			return basicNode?.SourceTypeReference;
		}

		

		public TypeReference GetInternalTypeReference(StructuralRuntimicModelMask_I model, TypeReference typeReference)
		{
			if (!Types.IsExternal(typeReference)) return typeReference;

			return Types.External.Resolve(model, typeReference);
		}

		

		public TypeReference GetInternalTypeReference(StructuralRuntimicModelMask_I model, Type input)
		{
			string resolutionName = Types.Naming.GetResolutionName(input);

			TypeReference typeDefinition = GetStoredTypeReference(model, resolutionName);

			if (typeDefinition != null) return typeDefinition;

			if (!input.IsGenericType)
			{
				throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
			}

			var genericArguments = input.GenericTypeArguments;

			var genericTypeDefinition = input.GetGenericTypeDefinition();

			var genericTypeDefinition1 = GetInternalTypeReference(model, genericTypeDefinition);

			var genericArgumentReferences = new TypeReference[genericArguments.Length];

			for (int i = 0; i < genericArguments.Length; i++)
			{
				genericArgumentReferences[i] = GetInternalTypeReference(model, genericArguments[i]);
			}

			var result = genericTypeDefinition1.MakeGenericInstanceType(genericArgumentReferences);

			return result;
		}
	}
}
