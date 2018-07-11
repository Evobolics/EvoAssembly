using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public class EnsuringApi<TContainer> : BindingApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    /// <summary>
	    /// Ensure the assembly that the specified type reference is from is part of the model.  The issue with assemblies is that they are top level
	    /// metadata.  Therefore it 
	    /// </summary>
	    /// <param name="model"></param>
	    /// <param name="typeReference"></param>
	    /// <returns></returns>
	    public SemanticAssemblyMask_I Ensure(InfrastructureModelMask_I model, TypeReference typeReference)
	    {
			// Search the model.
		    var assemblyEntry = Binding.Models.Assemblies.Get(model, typeReference);

		    if (assemblyEntry != null) return assemblyEntry;

			// Ensures the assembly definition that is associated with the type reference is part of the unified model and 
			// returns it.
		    AssemblyDefinition assemblyDefinition = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(model, typeReference);

		    return Ensure_Internal(model, assemblyDefinition, null);
	    }

	    public SemanticAssemblyMask_I Ensure(InfrastructureModelMask_I semanticModel, Assembly assembly)
	    {
		    if (semanticModel.Semantic.Assemblies.ByResolutionName.TryGetValue(assembly.FullName, out SemanticAssemblyMask_I assemblyEntry))
		    {
			    return assemblyEntry;
		    }

		    var assemblyDefinition = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(semanticModel, assembly);

			return Ensure_Internal(semanticModel, assemblyDefinition, assembly);
	    }


		/// <summary>
		///Ensures the assembly and only the assembly is present.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="assemblyDefinition"></param>
		/// <returns></returns>
		public SemanticAssemblyMask_I Ensure(InfrastructureModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
        {
            string resolutionName = Assemblies.Naming.GetResolutionName(assemblyDefinition);

            if (Models.Assemblies.TryGet(semanticModel, resolutionName, out SemanticAssemblyMask_I assemblyEntry))
            {
                return assemblyEntry;
            }

	        return Ensure_Internal(semanticModel, assemblyDefinition, null);
        }

	    public SemanticAssemblyMask_I Ensure_Internal(InfrastructureModelMask_I semanticModel,AssemblyDefinition assemblyDefinition, Assembly assembly)
	    {
			var assemblyEntry = Assemblies.Creation.CreateAssemblyEntry(semanticModel, assemblyDefinition, assembly);
			
			Assemblies.Addition.AddAssemblyEntry(semanticModel, assemblyEntry);

		    return assemblyEntry;
	    }


	}
}
