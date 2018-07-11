using System.Diagnostics;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class GenericClassWithMethods<TClass>
    {
        public void CallDoubleGenericArgs<TMethod>()
        {
            Debug.WriteLine(typeof(TMethod));
            Debug.WriteLine(typeof(TClass));
            Debug.WriteLine(typeof(System.Object));

        }
    }
}
