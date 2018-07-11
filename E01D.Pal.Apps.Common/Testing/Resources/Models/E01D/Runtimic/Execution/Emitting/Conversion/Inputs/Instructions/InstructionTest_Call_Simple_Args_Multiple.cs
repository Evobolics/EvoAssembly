namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_Call_Simple_Args_Multiple
    {
        public bool Execute()
        {
            Call1(1, 2, new object());

            return true;
        }

        public bool Call1(int a, int b, object c)
        {
            return a + b == 3;
        }
    }
}
