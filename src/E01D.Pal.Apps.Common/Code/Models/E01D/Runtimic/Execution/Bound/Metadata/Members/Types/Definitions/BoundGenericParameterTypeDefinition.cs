using System.Collections.Generic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundGenericParameterTypeDefinition : BoundTypeDefinition, BoundGenericParameterTypeDefinition_I, ExecutionTypeParameterDefinition_I
    {
        

        public TypeParameterConstraintKind Attributes { get; set; }
        public override TypeKind TypeKind => base.TypeKind | TypeKind.TypeParameter;


        public BoundTypeDefinitionMask_I DeclaringTypeDefinitionEntry { get; set; }

        public ExecutionClassTypeParameterConstraintMask_I BaseTypeConstraint { get; set; }

        public List<ExecutionInterfaceTypeParameterConstraintMask_I> InterfaceTypeConstraints { get; set; } = new List<ExecutionInterfaceTypeParameterConstraintMask_I>();

        public int Position { get; set; }
        public TypeParameterKind TypeParameterKind { get; set; }
        public GenericParameter Definition { get; set; }
    }
}
