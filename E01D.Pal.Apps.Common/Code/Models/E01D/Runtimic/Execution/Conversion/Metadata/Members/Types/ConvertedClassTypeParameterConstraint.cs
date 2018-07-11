using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public class ConvertedClassTypeParameterConstraint: ConvertedTypeParameterConstraint, SemanticClassTypeParameterConstraintMask_I
    {
        public SemanticTypeDefinitionMask_I Class { get; set; }

        public override SemanticTypeDefinitionMask_I SemanticType => Class;
    }
}
