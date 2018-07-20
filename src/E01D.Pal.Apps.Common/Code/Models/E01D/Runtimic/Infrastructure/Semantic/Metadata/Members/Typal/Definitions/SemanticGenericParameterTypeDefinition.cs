using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public class SemanticGenericParameterTypeDefinition: SemanticTypeDefinition, SemanticGenericParameterTypeDefinition_I
    {
        public int Position { get; set; } = -1;

        public TypeParameterKind TypeParameterKind { get; set; } = TypeParameterKind.Unknown;
        public GenericParameter Definition { get; set; }

        
    }
}
