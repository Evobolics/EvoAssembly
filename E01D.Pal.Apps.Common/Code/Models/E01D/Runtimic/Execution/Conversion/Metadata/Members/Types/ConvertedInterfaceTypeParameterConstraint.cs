using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public class ConvertedInterfaceTypeParameterConstraint: ConvertedTypeParameterConstraint
    {
        public SemanticTypeDefinitionMask_I Interface { get; set; }

        public override SemanticTypeDefinitionMask_I SemanticType => Interface;
        
    }
}
