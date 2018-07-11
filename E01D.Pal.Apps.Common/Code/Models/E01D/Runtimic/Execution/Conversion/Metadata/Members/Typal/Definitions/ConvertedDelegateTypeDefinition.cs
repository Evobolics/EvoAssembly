using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
	public class ConvertedDelegateTypeDefinition: ConvertedReferenceTypeDefinition,
        ConvertedDelegateTypeDefinitionMask_I, 
        ConvertedTypeDefinitionWithMethods_I,
	    ConvertedTypeDefinitionWithConstructors_I
    {

        public ConvertedTypeDefinitionConstructors Constructors { get; set; } = new ConvertedTypeDefinitionConstructors();

        SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

        public ConvertedTypeDefinitionMethods Methods { get; set; } = new ConvertedTypeDefinitionMethods();

        SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Delegate;
    }
}
