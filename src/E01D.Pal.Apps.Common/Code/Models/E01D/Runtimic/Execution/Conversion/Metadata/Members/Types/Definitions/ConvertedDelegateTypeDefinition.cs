﻿using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
	public class ConvertedDelegateTypeDefinition: ConvertedReferenceTypeDefinition,
        ConvertedDelegateTypeDefinitionMask_I, 
	    ConvertedTypeWithConstructors_I
    {
        public ConvertedTypeDefinitionConstructors Constructors { get; set; } = new ConvertedTypeDefinitionConstructors();

        SemanticTypeConstructorsMask_I SemanticTypeWithConstructorsMask_I.Constructors => this.Constructors;

        

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Delegate;
    }
}
