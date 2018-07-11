namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_And
    {
        public bool Execute1()
        {
            bool a = true;
            bool b = true;

            return a & b;

        }

        public bool Execute2()
        {
            bool a = false;
            bool b = true;

            return a & b;

        }

        public bool Execute3()
        {
            bool a = true;
            bool b = false;

            return a & b;

        }

        public bool Execute4()
        {
            bool a = false;
            bool b = false;

            return a & b;

        }
    }
}
