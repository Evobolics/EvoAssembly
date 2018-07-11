using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Cl.Conceptual.Metadata.Members.Typal
{
    public interface ClClassType_I:ClReferenceType_I, ClassType_I
    {
        ClassTypeKind ClassKind { get; }
    }
}
