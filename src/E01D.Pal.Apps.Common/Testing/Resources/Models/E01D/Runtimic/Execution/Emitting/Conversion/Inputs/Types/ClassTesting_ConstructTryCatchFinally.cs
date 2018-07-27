using System;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class ClassTesting_ConstructTryCatchFinally
    {
        public int Result = 0;

        public ClassTesting_ConstructTryCatchFinally()
        {
            var a = 0;
            try
            {
                a = a / Result;
            }
            catch (Exception)
            {
                a = 1;
            }
            finally
            {
                a += 1;
            }

            Result = a;
        }
    }
}
