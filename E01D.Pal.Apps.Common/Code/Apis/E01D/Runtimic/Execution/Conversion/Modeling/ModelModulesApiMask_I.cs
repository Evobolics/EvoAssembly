using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling
{
    public interface ModelModulesApiMask_I
    {
	    SemanticModuleMask_I GetModule(ILConversion conversion, SemanticAssemblyMask_I modulesAssembly,
		    TypeReference typeReference);

    }
}
