using System.Collections.Generic;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public class SemanticTypeDefinition: SemanticType, SemanticTypeDefinition_I
    {
        public TypeReference SourceTypeReference => throw new System.NotImplementedException();

        

	    public Dictionary<int, SemanticArrayTypeDefinitionMask_I> Arrays { get; set; } = new Dictionary<int, SemanticArrayTypeDefinitionMask_I>();
	}
}
