using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundConstructorDefinitionMask_I: BoundMemberDefinitionMask_I, SemanticConstructorMask_I
    {
        ConstructorInfo UnderlyingConstructor { get; }
    }
}
