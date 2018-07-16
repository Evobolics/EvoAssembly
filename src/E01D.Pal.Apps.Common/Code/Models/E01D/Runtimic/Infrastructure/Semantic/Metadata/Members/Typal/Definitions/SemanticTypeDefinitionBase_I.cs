using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticTypeDefinitionBase_I: SemanticTypeDefinitionMask_I, TypeDefinitionBase_I
    {
        new string Name { get; set; }
        new string FullName { get; set; }

        new TypeKind TypeKind { get; set; }

        new SemanticModuleMask_I Module { get; set; }

        

        new TypeReference SourceTypeReference { get; set; }

        new System.Reflection.Emit.PackingSize PackingSize { get; set; }
    }
}
