using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_Call_Simple_Generic
    {
        public bool Execute()
        {
            //Call1<object>();

            //Call1<SimpleClass>();

            //GenericClassWithMethods x = new GenericClassWithMethods();
            GenericClassWithMethods<object> x = new GenericClassWithMethods<object>();

            x.CallDoubleGenericArgs<SimpleClass>();
            //x.CallDoubleGenericArgs<object>();

            //GenericClassWithMethods<SimpleClass> x1 = new GenericClassWithMethods<SimpleClass>();

            //x1.CallDoubleGenericArgs<SimpleClass>();
            //x1.CallDoubleGenericArgs<object>();

            return true;
        }

        //public void Call1<T>()
        //{
        //    Debug.WriteLine(typeof(T));
        //    Debug.WriteLine(typeof(System.Object));

        //}


    }
}
