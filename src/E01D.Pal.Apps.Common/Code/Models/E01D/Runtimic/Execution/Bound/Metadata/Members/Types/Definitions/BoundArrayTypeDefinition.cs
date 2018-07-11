using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundArrayTypeDefinition : BoundReferenceTypeDefinition, BoundArrayTypeDefinition_I
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.Array;

        public SemanticTypeDefinitionMask_I ElementType { get; set; }

	    public BoundTypeDefinitionMethods Methods { get; set; } = new BoundTypeDefinitionMethods();

	    SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;
	}
}
