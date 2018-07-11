using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface  SemanticGenericParameterTypeDefinition_I: SemanticGenericParameterTypeDefinitionMask_I
    {
        new int Position { get; set; }

        new TypeParameterKind TypeParameterKind { get; set; }

        new GenericParameter Definition { get; set; }
    }
}
