using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_CastClass
    {
        public bool Execute()
        {
            BaseClassC c = new BaseClassC();

            BaseClassB b = (BaseClassB) c;

            BaseClassA a = Get<BaseClassA>(b);

            Interface1 a1 = (Interface1) a;

            // Performs the actual cast class
            var a2 = (BaseClassA) a1;

            var c2 = Get<BaseClassC>(a2);

            return c2 != null;
        }

        public T Get<T>(Interface1 baseClassB)
            where T : class
        {
            return (T)baseClassB;
        }
    }
}
