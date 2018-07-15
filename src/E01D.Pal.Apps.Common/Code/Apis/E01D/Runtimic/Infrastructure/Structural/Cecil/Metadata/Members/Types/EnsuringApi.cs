using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class EnsuringApi<TContainer> : CecilApiNode<TContainer>, EnsuringApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public CecilTypeReferenceSet EnsureReferences(InfrastructureRuntimicModelMask_I model, Type[] types)
		{
			var result = new CecilTypeReferenceSet();

			for (int i = 0; i < types.Length; i++)
			{
				EnsureReference(model, types[i], out UnifiedTypeNode unifiedNode);

				result.Types.Add(unifiedNode);

				if (!IsPresent(result, unifiedNode.AssemblyNode))
				{
					result.Assemblies.Add(unifiedNode.AssemblyNode);
				}
			}

			return result;
		}

		public CecilTypeReferenceSet EnsureReferences(InfrastructureRuntimicModelMask_I model, List<TypeReference> types)
		{
			var result = new CecilTypeReferenceSet();

			for (int i = 0; i < types.Count; i++)
			{
				EnsureReference(model, types[i], out UnifiedTypeNode unifiedNode);

				result.Types.Add(unifiedNode);

				if (!IsPresent(result, unifiedNode.AssemblyNode))
				{
					result.Assemblies.Add(unifiedNode.AssemblyNode);
				}
			}

			return result;
		}

		private bool IsPresent(CecilTypeReferenceSet result, UnifiedAssemblyNode assemblyNode)
		{
			for (int i = 0; i < result.Assemblies.Count; i++)
			{
				if (ReferenceEquals(result.Assemblies[i], assemblyNode)) return true;
			}

			return false;
		}

		public TypeReference EnsureReference(InfrastructureRuntimicModelMask_I model, Type type)
		{
			return EnsureReference(model, type, out UnifiedTypeNode unifiedNode);
		}

		public TypeReference EnsureReference(InfrastructureRuntimicModelMask_I model, Type type, out UnifiedTypeNode unifiedNode)
		{

			
			string resolutionName = Types.Naming.GetResolutionName(type);

			//if (resolutionName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.ComplicatedGenericWithOneArgBaseConstructorCall`3, E01D.Pal.Apps.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
			//{
				
			//}

			TypeReference result = Types.Getting.GetStoredTypeReference(model, resolutionName, out unifiedNode);

			if (result != null) return result;

			if (type.IsGenericType && !type.IsGenericTypeDefinition)
			{
				var genericArguments = type.GenericTypeArguments;

				var genericTypeDefinition = type.GetGenericTypeDefinition();

				var genericTypeDefinition1 = EnsureReference(model, genericTypeDefinition);

				var genericArgumentReferences = new TypeReference[genericArguments.Length];

				for (int i = 0; i < genericArguments.Length; i++)
				{
					genericArgumentReferences[i] = EnsureReference(model, genericArguments[i]);
				}

				result = genericTypeDefinition1.MakeGenericInstanceType(genericArgumentReferences);

				var assemblyNode = Assemblies.Ensuring.Ensure(model, type.Assembly);

				var moduleNode = Unified.Modules.Get(model, type.Module.Name);

				Unified.Types.Extend(model, assemblyNode, moduleNode, result);
			}
			else
			{
				// This should load the assembly, module and types into the model.
				Assemblies.Ensuring.Ensure(model, type.Assembly);

				result = Types.Getting.GetStoredTypeReference(model, resolutionName, out unifiedNode);

				if (result == null)
				{
					throw new Exception($"Type definition for {type.AssemblyQualifiedName} is not loaded.");
				}
			}

			return result;
		}

		public TypeReference EnsureReference(InfrastructureRuntimicModelMask_I model, TypeReference inputReference)
		{
			return EnsureReference(model, inputReference, out UnifiedTypeNode unifiedNode);
		}

		public TypeReference EnsureReference(InfrastructureRuntimicModelMask_I model, TypeReference inputReference, out UnifiedTypeNode unifiedNode)
		{
			string resolutionName = Types.Naming.GetResolutionName(inputReference);

			var result = Types.Getting.GetStoredTypeReference(model, resolutionName, out unifiedNode);

			if (result != null) return result;

			if (inputReference.IsGenericInstance)
			{
				GenericInstanceType genericInstance = (GenericInstanceType) inputReference;

				var genericArguments = genericInstance.GenericArguments;

				var genericTypeDefinition = genericInstance.ElementType;

				var genericTypeDefinition1 = EnsureReference(model, genericTypeDefinition, out UnifiedTypeNode genericUnifiedNode);

				var genericArgumentReferences = new TypeReference[genericArguments.Count];

				for (int i = 0; i < genericArguments.Count; i++)
				{
					genericArgumentReferences[i] = EnsureReference(model, genericArguments[i]);
				}

				result = genericTypeDefinition1.MakeGenericInstanceType(genericArgumentReferences);

				var assemblyNode = Assemblies.Ensuring.Ensure(model, inputReference.Scope);

				//var moduleNode = Unified.Modules.Get(model, type.Module.Name);

				throw new Exception("Debug");

				//Unified.Types.Extend(model, assemblyNode, moduleNode, result);
			}
			else
			{
				// This should load the assembly, module and types into the model.
				Assemblies.Ensuring.Ensure(model, inputReference.Scope);

				result = Types.Getting.GetStoredTypeReference(model, resolutionName, out unifiedNode);

				if (result == null)
				{
					throw new Exception($"Type definition for {resolutionName} is not loaded.");
				}
			}

			return result;
		}


	}
}
