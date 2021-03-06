﻿using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticTypeDefinitionMask_I: SemanticTypeMask_I, TypeDefinitionMask_I
    {
	    SemanticTypeDefinitionMask_I BaseType { get; }

		/// <summary>
		/// Gets or sets the type definition that was used to created this semantic type.
		/// </summary>
		TypeReference SourceTypeReference { get; }

       

        System.Reflection.Emit.PackingSize PackingSize { get;  }

	    SemanticModuleMask_I Module { get; }

	    Dictionary<string, SemanticTypeMask_I> NestedTypes { get; }

	    //Dictionary<int, SemanticArrayTypeDefinitionMask_I> Arrays { get;  }
	    

	    
	}
}
