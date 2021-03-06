﻿using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeDefinition_I: ConvertedTypeDefinitionMask_I, ExecutionTypeDefinition_I
	{
	    

		//new ConvertedTypeDefinition_I DeclaringType { get; set; }

		/// <summary>
		/// Gets or sets whether the type has been built.  It has been built if a type builder has been assigned.
		/// </summary>

		


		new ConvertedModuleMask_I Module { get; set; }

	    new Dictionary<string, SemanticTypeMask_I> NestedTypes { get; set; }

		

	    

		new TypeBuilder TypeBuilder { get; set; }



	}
}
