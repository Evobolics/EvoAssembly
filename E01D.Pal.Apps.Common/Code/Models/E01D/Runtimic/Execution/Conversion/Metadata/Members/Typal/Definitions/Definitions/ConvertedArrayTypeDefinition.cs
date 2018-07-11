using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public class ConvertedArrayTypeDefinition : ConvertedReferenceTypeDefinition, ConvertedArrayTypeDefinition_I
    {
        
	    
	    public override TypeKind TypeKind => base.TypeKind | TypeKind.Array;

       

        public SemanticTypeDefinitionMask_I ElementType { get; set; }
    }
}
