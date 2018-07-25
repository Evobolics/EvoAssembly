using System.Collections.Generic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
    public interface ExecutionTypeParameterDefinition_I: ExecutionTypeParameterDefinitionMask_I, ExecutionTypeDefinition_I
    {
        TypeParameterConstraintKind Attributes { get; set; }



        BoundTypeDefinitionMask_I DeclaringTypeDefinitionEntry { get; set; }

		new ExecutionClassTypeParameterConstraintMask_I BaseTypeConstraint { get; set; }

        new List<ExecutionInterfaceTypeParameterConstraintMask_I> InterfaceTypeConstraints { get; set; } 

        new int Position { get; set; }
        new TypeParameterKind TypeParameterKind { get; set; }
        new GenericParameter Definition { get; set; }
    }
}
