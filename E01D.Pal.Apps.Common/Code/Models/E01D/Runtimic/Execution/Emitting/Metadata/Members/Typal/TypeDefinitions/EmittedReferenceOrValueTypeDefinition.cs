using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata.Members.Typal.TypeDefinitions
{
    public class EmittedReferenceOrValueTypeDefinition: EmittedTypeDefinition
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.Definition;
    }
}
