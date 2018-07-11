using System.Reflection.Emit;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public abstract class ConvertedReferenceTypeDefinition: ConvertedReferenceOrValueTypeDefinition, ConvertedReferenceTypeDefinitionMask_I
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.Reference;
        

        public GenericTypeParameterBuilder[] GenericTypeParameters { get; set; }
    }
}
