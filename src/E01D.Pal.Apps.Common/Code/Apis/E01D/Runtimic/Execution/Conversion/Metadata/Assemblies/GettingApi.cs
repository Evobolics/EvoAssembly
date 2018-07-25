using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public class GettingApi<TContainer> : ConversionApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    

	    public SemanticAssemblyMask_I GetAssembly(ILConversion conversion, AssemblyDefinition assemblyDefinition)
	    {
		    return GetAssembly(conversion.Model, assemblyDefinition);
	    }

	    public SemanticAssemblyMask_I GetAssembly(ILConversion conversion, Assembly assembly)
	    {
		    return GetAssembly(conversion.Model, assembly.FullName);
	    }

	    

	    

	    public SemanticAssemblyMask_I GetAssembly(InfrastructureRuntimicModelMask_I model, string resolutionName)
	    {
		    if (!Semantic.Metadata.Assemblies.TryGet(model, resolutionName, out SemanticAssemblyMask_I assemblyEntry))
		    {
			    return null;
		    }

		    return assemblyEntry;
	    }

	    public SemanticAssemblyMask_I GetAssembly(ILConversionRuntimicModel model, AssemblyDefinition assemblyDefinition)
	    {
		    return GetAssembly(model, assemblyDefinition.FullName);
	    }



	    

	    
	}
}
