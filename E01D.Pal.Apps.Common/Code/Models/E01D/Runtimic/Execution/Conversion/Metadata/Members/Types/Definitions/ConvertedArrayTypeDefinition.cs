using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedArrayTypeDefinition : ConvertedReferenceTypeDefinition, ConvertedArrayTypeDefinition_I
    {
        
	    
	    public override TypeKind TypeKind => base.TypeKind | TypeKind.Array;

	    public ConvertedTypeDefinitionConstructors Constructors { get; set; } = new ConvertedTypeDefinitionConstructors();

	    public SemanticTypeDefinitionMask_I ElementType { get; set; }

		public ConvertedTypeDefinitionMethods Methods { get; set; } = new ConvertedTypeDefinitionMethods();

	    SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

		SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

		
    }
}
