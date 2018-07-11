using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public interface SemanticModuleTypes_I
    {
        

        Dictionary<string, TypeDefinitionMask_I> DefinitionsByName { get; set; }

        Dictionary<string, TypeReferenceMask_I> ReferencesByName { get; set; } 

        Dictionary<string, SemanticTypeMask_I> ByResolutionName { get; set; } 
    }
}
