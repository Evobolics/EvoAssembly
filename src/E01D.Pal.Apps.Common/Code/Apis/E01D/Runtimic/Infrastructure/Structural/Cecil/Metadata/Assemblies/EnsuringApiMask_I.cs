using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public interface EnsuringApiMask_I
	{
		Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel,
			UnifiedAssemblyNode assemblyNode);

		Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel,
			List<UnifiedAssemblyNode> assemblyNodes);

		CecilTypeReferenceSet Ensure(InfrastructureRuntimicModelMask_I model, AssemblyDefinition[] assemblies);

		CecilTypeReferenceSet Ensure(InfrastructureRuntimicModelMask_I model, Assembly[] assemblies);

		/// <summary>
		/// Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="scope"></param>
		/// <returns></returns>
		UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, IMetadataScope scope);

		/// <summary>
		/// Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeReference"></param>
		/// <returns></returns>
		UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I model, TypeReference typeReference);

		UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, Assembly assembly);

		UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, Stream stream);

		UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, string fullName);

		
	}
}
