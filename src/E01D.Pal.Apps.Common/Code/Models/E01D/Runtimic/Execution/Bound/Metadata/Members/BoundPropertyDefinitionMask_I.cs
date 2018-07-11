using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundPropertyDefinitionMask_I: BoundMemberDefinitionMask_I, SemanticPropertyMask_I
    {
	    PropertyInfo UnderlyingPropertyInfo { get;  }
	}
}
