using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
    public interface AssemblyApiMask_I
    {
	    AssemblyDefinition Create(InfrastructureModelMask_I semanticModel, Assembly assembly);

	    AssemblyDefinition Create(InfrastructureModelMask_I semanticModel, Stream stream);

		


		string GetAssemblyName(TypeReference typeReference);

	    /// <summary>
	    /// Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
	    /// </summary>
	    /// <param name="semanticModel"></param>
	    /// <param name="scope"></param>
	    /// <returns></returns>
	    AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, IMetadataScope scope);

		/// <summary>
		/// Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeReference"></param>
		/// <returns></returns>
		AssemblyDefinition Ensure(InfrastructureModelMask_I model, TypeReference typeReference);

	    AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, Assembly assembly);

	    AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, Stream stream);

	    AssemblyDefinition Ensure(InfrastructureModelMask_I semanticModel, string fullName);

		string GetAssemblyName(IMetadataScope scope);
		
	}
}
