using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public interface DefinitionApiMask_I
	{
		

		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="typeDefinition"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		//MethodDefinition GetMethodDefinition(InfrastructureModelMask_I model, TypeDefinition typeDefinition, MethodInfo method);
	}
}
