﻿using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticGenericParameterTypeDefinitionMask_I: SemanticTypeDefinitionMask_I
    {
        int Position { get; }

        TypeParameterKind TypeParameterKind { get; }

        GenericParameter Definition { get; }
    }
}
