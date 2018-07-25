using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundInterfaceTypeParameterConstraint : BoundTypeParameterConstraint, BoundInterfaceTypeParameterConstraintMask_I
    {
        public ExecutionTypeDefinitionMask_I Interface { get; set; }
        
    }
}
