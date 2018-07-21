using System.Reflection.Emit;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundTypeDefinition_I:BoundType_I, BoundTypeDefinitionMask_I, ExecutionTypeDefinition_I
	{



		
		new PackingSize PackingSize { get; set; }

	    new BoundModuleMask_I Module { get; set; }

		
		
		
	}
}
