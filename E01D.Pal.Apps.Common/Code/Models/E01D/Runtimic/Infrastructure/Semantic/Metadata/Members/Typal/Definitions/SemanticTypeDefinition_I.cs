using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticTypeDefinition_I: SemanticTypeDefinitionMask_I
    {
	    new Dictionary<int, SemanticArrayTypeDefinitionMask_I> Arrays { get; set; }
	}
}
