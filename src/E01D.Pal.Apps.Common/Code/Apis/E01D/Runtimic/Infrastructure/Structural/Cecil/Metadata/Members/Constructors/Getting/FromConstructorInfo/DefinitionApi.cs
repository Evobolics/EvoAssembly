using System;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo
{
	public class DefinitionApi<TContainer> : CecilApiNode<TContainer>, DefinitionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		/// <summary>
		/// Gets the method definition that coresponds to the runtime method info.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeReference"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.  This method first gets the type definition associated with the 
		/// type reference.
		/// </summary>
		public MethodDefinition GetMethodDefinition(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, ConstructorInfo method)
		{
			// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
			var typeDefinition = Types.Getting.GetDefinition(model, typeReference);

			return GetMethodDefinition(model, typeDefinition, method);
		}

		/// <summary>
		/// Gets the method definition that coresponds to the runtime method info.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeDefinition"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		public MethodDefinition GetMethodDefinition(InfrastructureRuntimicModelMask_I model, TypeDefinition typeDefinition, ConstructorInfo method)
		{
			if (method.Module.Assembly.IsDynamic)
				throw new Exception(
					"Cannot be used for methods that orginate from dynamic assemblies as the metadata tokens will not match.");

			var methodDefinitions = typeDefinition.Methods;

			for (int i = 0; i < methodDefinitions.Count; i++)
			{
				var methodDefinition = methodDefinitions[i];

				if (method.MetadataToken == methodDefinition.MetadataToken.ToInt32()) return methodDefinition;
			}

			throw new Exception($"Could not find a method matching the method name {method.Name}.");
		}
	}
}
