using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundGenericParameterTypeDefinitionMask_I: BoundTypeDefinitionMask_I, ExecutionTypeParameterDefinitionMask_I
    {
        new List<ExecutionInterfaceTypeParameterConstraintMask_I> InterfaceTypeConstraints { get; set; }
    }
}
