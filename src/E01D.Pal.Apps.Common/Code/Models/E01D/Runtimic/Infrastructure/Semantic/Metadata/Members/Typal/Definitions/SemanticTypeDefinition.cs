using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public class SemanticTypeDefinition: SemanticType, SemanticTypeDefinition_I
    {
	    public SemanticTypeDefinitionMask_I BaseType { get; set; }
	    public TypeReference SourceTypeReference => throw new System.NotImplementedException();

        

	    
	}
}
