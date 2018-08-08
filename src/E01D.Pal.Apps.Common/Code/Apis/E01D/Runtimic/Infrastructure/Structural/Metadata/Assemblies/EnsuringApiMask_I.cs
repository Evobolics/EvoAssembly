using System.IO;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Assemblies
{
	public interface EnsuringApiMask_I
	{
		//Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel,
		//	UnifiedAssemblyNode assemblyNode);

		//Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel,
		//	List<UnifiedAssemblyNode> assemblyNodes);

		//CecilTypeReferenceSet Ensure(RuntimicSystemModel model, AssemblyDefinition[] assemblies);

		StructuralAssemblyNode[] Ensure(RuntimicSystemModel model, Assembly[] assemblies);

		StructuralAssemblyNode Ensure(RuntimicSystemModel model, Assembly assembly);

		/// <summary>
		/// Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="scope"></param>
		/// <returns></returns>
		StructuralAssemblyNode Ensure(RuntimicSystemModel semanticModel, IMetadataScope scope);

		/// <summary>
		/// Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeReference"></param>
		/// <returns></returns>
		StructuralAssemblyNode Ensure(RuntimicSystemModel model, TypeReference typeReference);

		//StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, Assembly assembly);

		StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, Stream stream);



		StructuralAssemblyNode Ensure(RuntimicSystemModel semanticModel, string fullName);

		
	}
}
