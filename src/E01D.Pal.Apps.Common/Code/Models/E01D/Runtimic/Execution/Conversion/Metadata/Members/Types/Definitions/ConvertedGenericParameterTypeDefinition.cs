using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedGenericParameterTypeDefinition: ConvertedTypeDefinition, ConvertedGenericParameterTypeDefinition_I
    {
        public ConvertedGenericParameterTypeDefinition()
        {
            
        }

        public TypeParameterConstraintKind Attributes { get; set; }
        public override TypeKind TypeKind => base.TypeKind | TypeKind.TypeParameter;
        
        
        public ConvertedTypeDefinitionMask_I DeclaringTypeDefinitionEntry { get; set; }
        public GenericTypeParameterBuilder Builder { get; set; }
        public GenericParameter Definition { get; set; }

        public ConvertedClassTypeParameterConstraint BaseTypeConstraint { get; set; }

        public List<ConvertedInterfaceTypeParameterConstraint> InterfaceTypeConstraints { get; set; } = new List<ConvertedInterfaceTypeParameterConstraint>();
        public int Position { get; set; } = -1;

        public TypeParameterKind TypeParameterKind { get; set; } = TypeParameterKind.Unknown;
    }
}
