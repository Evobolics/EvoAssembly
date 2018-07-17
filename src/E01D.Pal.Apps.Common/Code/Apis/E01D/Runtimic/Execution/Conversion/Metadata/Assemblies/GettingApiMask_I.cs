using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface GettingApiMask_I
    {
		SemanticAssemblyMask_I GetAssembly(ILConversion conversion, AssemblyDefinition assemblyDefinition);

	    SemanticAssemblyMask_I GetAssembly(ILConversion conversion, Assembly assembly);

	    SemanticAssemblyMask_I GetAssembly(InfrastructureRuntimicModelMask_I model, string fullName);

	    SemanticAssemblyMask_I GetAssembly(InfrastructureRuntimicModelMask_I model, AssemblyNameReference fullName);

	    SemanticAssemblyMask_I GetAssembly(ILConversionRuntimicModel conversion, AssemblyDefinition assemblyDefinition);

	    AssemblyDefinitionAndStream GetAssemblyDefinition(ILConversion conversion, Assembly assembly);

		bool TryGet(ILConversion conversion, string fullName, out SemanticAssemblyMask_I semanticAssemblyMask);
	}
}
