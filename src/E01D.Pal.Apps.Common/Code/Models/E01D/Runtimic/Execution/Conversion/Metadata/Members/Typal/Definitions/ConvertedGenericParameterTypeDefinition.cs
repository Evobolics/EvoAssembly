using System.Collections.Generic;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public class ConvertedGenericParameterTypeDefinition: ConvertedTypeDefinition, ConvertedGenericParameterTypeDefinition_I
    {
        public TypeParameterConstraintKind Attributes { get; set; }
        public override TypeKind TypeKind => base.TypeKind | TypeKind.TypeParameter;
        
        
        public ConvertedTypeDefinition_I DeclaringTypeDefinitionEntry { get; set; }
        public GenericTypeParameterBuilder Builder { get; set; }
        public GenericParameter Definition { get; set; }

        public ConvertedClassTypeParameterConstraint BaseTypeConstraint { get; set; }

        public List<ConvertedInterfaceTypeParameterConstraint> InterfaceTypeConstraints { get; set; } = new List<ConvertedInterfaceTypeParameterConstraint>();
        public int Position { get; set; } = -1;

        public TypeParameterKind TypeParameterKind { get; set; } = TypeParameterKind.Unknown;
    }
}
