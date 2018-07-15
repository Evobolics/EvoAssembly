using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public interface EnsuringApiMask_I
    {
	    SemanticModuleMask_I EnsureAssignedModule(ILConversion conversion, TypeReference input);

	    SemanticModuleMask_I EnsureAssignedModule(ILConversion conversion, System.Type input);

		//List<SemanticModuleMask_I> EnsureModuleEntries(BoundAssemblyMask_I entry);
    }
}
