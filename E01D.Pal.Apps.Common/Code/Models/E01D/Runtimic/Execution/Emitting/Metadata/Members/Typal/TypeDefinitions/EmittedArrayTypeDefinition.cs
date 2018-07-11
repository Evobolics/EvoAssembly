using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata.Members.Typal.TypeDefinitions
{
    public class EmittedArrayTypeDefinition:EmittedReferenceTypeDefinition
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.Array;

        
    }
}
