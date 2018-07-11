namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_AddOvfUn
    {
        public uint Execute()
        {
            uint a = 2;
            uint b = 2;
            uint c;
            checked
            {

                c = a + b;
            }

            return c;

        }
    }
}
