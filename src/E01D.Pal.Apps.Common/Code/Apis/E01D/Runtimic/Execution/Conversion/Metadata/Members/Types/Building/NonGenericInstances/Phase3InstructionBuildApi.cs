using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
	public class Phase3InstructionBuildApi<TContainer> : ConversionApiNode<TContainer>, Phase3InstructionBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Build(ILConversion conversion, ConvertedTypeDefinition_I converted)
		{
			// DESIGN NOTE:
			// Need to place this in this phase after members have been created, and after generic instances have been able to get a copy of the methods.
			// The instructions for this converted type can need generic instances of this type, which in turn need to have the methods already added
			// so their methods can be created. 

			// The generic instances need the methods that orginate from this phase. 
			Instructions.Building.BuildInstructions(conversion, converted);

			Methods.Building.Emitted.AddAllMethodOverrides(conversion, converted);
		}
	}
}
