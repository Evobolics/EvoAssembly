namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_Call_Simple_Args
    {
        public bool Execute()
        {
            Call1(1);

            return true;
        }

        public bool Call1(int a)
        {
            return true;
        }
    }
}
