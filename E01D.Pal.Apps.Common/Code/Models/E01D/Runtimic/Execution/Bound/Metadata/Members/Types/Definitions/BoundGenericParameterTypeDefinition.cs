using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundGenericParameterTypeDefinition : BoundTypeDefinition, BoundGenericParameterTypeDefinition_I
	{
        

        public TypeParameterConstraintKind Attributes { get; set; }
        public override TypeKind TypeKind => base.TypeKind | TypeKind.TypeParameter;


        public BoundTypeDefinition DeclaringTypeDefinitionEntry { get; set; }

        public BoundClassTypeParameterConstraint BaseTypeConstraint { get; set; }

        public List<BoundInterfaceTypeParameterConstraint> InterfaceTypeConstraints { get; set; } = new List<BoundInterfaceTypeParameterConstraint>();

        public int Position { get; set; }
        public TypeParameterKind TypeParameterKind { get; set; }
        public GenericParameter Definition { get; set; }
    }
}
