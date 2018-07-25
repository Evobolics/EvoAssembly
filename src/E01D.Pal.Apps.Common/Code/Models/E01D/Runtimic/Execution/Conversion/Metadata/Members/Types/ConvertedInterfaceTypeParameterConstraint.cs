using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public class ConvertedInterfaceTypeParameterConstraint: ConvertedTypeParameterConstraint, ExecutionInterfaceTypeParameterConstraintMask_I
    {
        public ExecutionTypeDefinitionMask_I Interface { get; set; }

        public override SemanticTypeDefinitionMask_I SemanticType => Interface;
        
    }
}
