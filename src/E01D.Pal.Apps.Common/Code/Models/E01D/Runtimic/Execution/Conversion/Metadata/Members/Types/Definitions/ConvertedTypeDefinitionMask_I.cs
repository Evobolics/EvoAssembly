using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeDefinitionMask_I: ConvertedClassTypeDefinitionClassifier_I, ConvertedTypeMask_I, BoundTypeDefinitionMask_I
    {
		//ConvertedTypeDefinition_I DeclaringType { get; }

		

		List<ConvertedTypeDefinition_I> Phase2Dependencies { get; }

	    /// <summary>
	    /// Gets or sets all of the conversion entries that are directly dependent upon this entry.
	    /// </summary>
	    List<ConvertedTypeDefinition_I> Phase2Dependents { get; }

	    List<ConvertedTypeDefinition_I> Phase3Dependencies { get; }

	    /// <summary>
	    /// Gets or sets all of the conversion entries that are directly dependent upon this entry.
	    /// </summary>
	    List<ConvertedTypeDefinition_I> Phase3Dependents { get; }

		new ConvertedModuleMask_I Module { get;  }

	    TypeBuilder TypeBuilder { get; }

	}
}
