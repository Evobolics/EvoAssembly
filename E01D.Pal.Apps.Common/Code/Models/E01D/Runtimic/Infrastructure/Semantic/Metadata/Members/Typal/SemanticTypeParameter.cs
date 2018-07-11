
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public class SemanticTypeParameter : SemanticTypeParameter_I
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public SemanticParameterTypeDefinitionConstraintMask_I[] Constraints { get; set; }

        public TypeParameterConstraintKind Attributes { get; set; }
    }
}
