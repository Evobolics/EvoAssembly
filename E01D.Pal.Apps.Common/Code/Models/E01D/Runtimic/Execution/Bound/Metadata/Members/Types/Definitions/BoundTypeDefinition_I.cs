using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundTypeDefinition_I:BoundType_I, BoundTypeDefinitionMask_I
	{



		new int BuildPhase { get; set; }
		new PackingSize PackingSize { get; set; }

	    new BoundModuleMask_I Module { get; set; }
	}
}
