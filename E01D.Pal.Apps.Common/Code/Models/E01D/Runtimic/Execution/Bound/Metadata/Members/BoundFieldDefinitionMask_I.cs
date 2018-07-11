using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundFieldDefinitionMask_I: BoundMemberDefinitionMask_I, SemanticFieldMask_I
    {
        FieldInfo UnderlyingField { get; }

        new BoundTypeMask_I FieldType { get;  }
        
    }
}
