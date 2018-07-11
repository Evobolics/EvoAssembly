using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedGenericTypeDefinition_I: ConvertedTypeDefinition_I, BoundGenericTypeDefinitionMask_I, ConvertedTypeDefinitionWithTypeParameters_I, GenericType_I
    {
        List<BoundTypeDefinitionMask_I> TypeArguments { get; set; } //cannot be in dictionary as order matters.
        new SemanticTypeDefinitionMask_I Blueprint { get; set; }
        GenericInstanceType SourceGenericInstanceType { get; set; }

        TypeDefinition SourceGenericTypeDefinition { get; set; }
    }
}
