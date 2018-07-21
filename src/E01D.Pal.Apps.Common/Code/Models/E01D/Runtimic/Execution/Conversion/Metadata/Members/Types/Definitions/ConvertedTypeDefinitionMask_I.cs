using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeDefinitionMask_I: ConvertedClassTypeDefinitionClassifier_I, ConvertedTypeMask_I, BoundTypeDefinitionMask_I
    {
		

		

		

	    

		new ConvertedModuleMask_I Module { get;  }

	    TypeBuilder TypeBuilder { get; }

	}
}
