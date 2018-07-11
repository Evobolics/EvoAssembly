using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_Call_TwoTypes
    {
        public bool Execute()
        {
            Call1(null);

            return true;
        }

        public void Call1(SimpleClass simpleClass)
        {

        }
    }
}
