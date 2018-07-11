using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public class ConvertedGenericNestedInterfaceTypeDefinition: ConvertedNestedInterfaceTypeDefinition, ConvertedGenericTypeDefinition_I
    {
        public SemanticTypeDefinitionMask_I Blueprint { get; set; }

        SemanticTypeMask_I SemanticGenericTypeDefinitionMask_I.Blueprint => Blueprint;

        public GenericTypeKind GenericKind { get; set; }

        public TypeReference GenericTypeDefinition { get; set; }

        public GenericInstanceType SourceGenericInstanceType { get; set; }

        public TypeDefinition SourceGenericTypeDefinition { get; set; }

        public List<BoundTypeDefinitionMask_I> TypeArguments { get; set; } = new List<BoundTypeDefinitionMask_I>();

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Generic;

        public ConvertedGenericParameterTypeDefinitions_I TypeParameters { get; set; } = new ConvertedGenericParameterTypeDefinitions();


        SemanticGenericParameterTypeDefinitionsMask_I SemanticTypeDefinitionWithTypeParametersMask_I.TypeParameters => TypeParameters;
        BoundGenericParameterTypeDefinitionsMask_I BoundTypeDefinitionWithTypeParametersMask_I.TypeParameters => TypeParameters;
        ConvertedGenericParameterTypeDefinitionsMask_I ConvertedTypeDefinitionWithTypeParametersMask_I.TypeParameters => TypeParameters;



    }
}
