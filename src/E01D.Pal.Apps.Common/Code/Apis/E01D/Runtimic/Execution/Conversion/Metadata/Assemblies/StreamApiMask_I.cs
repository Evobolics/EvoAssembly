using System.IO;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface StreamApiMask_I
	{
	    ILConversionResult Convert(ILConversion conversion, Stream[] streams);



	    void AddDynamicAssemblyReferences(ILConversion conversion);







	    void AddAssemblyReferences(ILConversion conversion, SemanticAssemblyMask_I assemblyEntry);
    }
}
