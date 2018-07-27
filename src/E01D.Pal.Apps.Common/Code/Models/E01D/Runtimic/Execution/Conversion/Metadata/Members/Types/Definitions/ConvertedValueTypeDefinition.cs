using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    /// <summary>
    /// 
    /// </summary>
    /// <notes>
    /// Enums cannot have methods and therefore that is the reason why ConvertedValueTypeDefinition does not 
    /// support having routines, constructors or methods.
    /// </notes>
    public abstract class ConvertedValueTypeDefinition : ConvertedReferenceOrValueTypeDefinition
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.ValueType;
    }
}
