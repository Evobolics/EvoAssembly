using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata.Members.Typal.TypeDefinitions
{
    public abstract class EmittedReferenceTypeDefinition:EmittedReferenceOrValueTypeDefinition
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.ReferenceType;
    }
}
