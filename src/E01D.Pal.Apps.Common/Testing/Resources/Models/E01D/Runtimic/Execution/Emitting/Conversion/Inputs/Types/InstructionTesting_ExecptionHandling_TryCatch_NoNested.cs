namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class InstructionTesting_ExecptionHandling_TryCatch_NoNested
    {
        public object Execute()
        {
            try
            {
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
