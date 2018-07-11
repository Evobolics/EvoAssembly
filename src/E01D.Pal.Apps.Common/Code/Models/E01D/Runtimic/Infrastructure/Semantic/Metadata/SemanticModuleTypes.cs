using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata
{
    public class SemanticModuleTypes: SemanticModuleTypes_I
    {
        public List<SemanticTypeMask_I> InDependencyOrder { get; set; }

        public Dictionary<string, TypeDefinitionMask_I> DefinitionsByName { get; set; } = new Dictionary<string, TypeDefinitionMask_I>();

        public Dictionary<string, TypeReferenceMask_I> ReferencesByName { get; set; } = new Dictionary<string, TypeReferenceMask_I>();

        public Dictionary<string, SemanticTypeMask_I> ByResolutionName { get; set; } = new Dictionary<string, SemanticTypeMask_I>();
    }
}
