using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public interface DefinitionApiMask_I
	{
		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.  This method first gets the type definition associated with the 
		/// type reference.
		/// </summary>
		MethodDefinition GetMethodDefinition(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, MethodInfo method);

		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeDefinition"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		MethodDefinition GetMethodDefinition(InfrastructureRuntimicModelMask_I model, TypeDefinition typeDefinition, MethodInfo method);

		MethodDefinition GetMethodDefinition(InfrastructureRuntimicModelMask_I model,Mono.Collections.Generic.Collection<MethodDefinition> methodDefinitions, MethodInfo method);
	}
}
