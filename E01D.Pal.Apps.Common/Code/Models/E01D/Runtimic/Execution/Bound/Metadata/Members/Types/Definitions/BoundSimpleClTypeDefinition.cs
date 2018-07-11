using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundSimpleClTypeDefinition : BoundValueTypeDefinition, BoundTypeDefinitionWithFields_I, BoundTypeDefinitionWithMethods_I
	{
        public override TypeKind TypeKind => base.TypeKind | TypeKind.Simple | TypeKind.CommonLanguage;

		public BoundTypeDefinitionFields Fields { get; set; } = new BoundTypeDefinitionFields();

		public BoundTypeDefinitionMethods Methods { get; set; } = new BoundTypeDefinitionMethods();

		SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

		SemanticTypeFieldsMask_I SemanticTypeDefinitionWithFieldsMask_I.Fields => Fields;
	}
}
