using System;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata.Members.Typal
{
    public class EmittedTypeDefinition:EmittedType
    {
        public Type Type { get; set; }

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Definition;
    }
}
