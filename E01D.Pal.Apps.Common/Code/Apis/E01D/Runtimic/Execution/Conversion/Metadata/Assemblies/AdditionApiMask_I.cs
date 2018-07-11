using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface AdditionApiMask_I
	{
		void AddAssemblyEntry(ILConversion conversion, SemanticAssemblyMask_I assembly);
	    
	    void AddAssociatedDefinition(ILConversion conversion, ConvertedAssembly convertedAssembly, AssemblyDefinitionAndStream definition);
	}
}
