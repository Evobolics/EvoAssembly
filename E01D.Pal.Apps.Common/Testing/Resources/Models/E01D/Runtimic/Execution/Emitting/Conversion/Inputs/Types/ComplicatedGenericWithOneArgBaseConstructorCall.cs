namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class ComplicatedGenericWithOneArgBaseConstructorCall<A, B, C> : BaseGenericWithOneArgConstructor<A, B, C>
        where A : Interface1
        where B : Interface2
        where C : Interface3

    {
        public ComplicatedGenericWithOneArgBaseConstructorCall()
            :base("test message")
        {
            
        }

        public object Execute()
        {
            return base.Message;
        }


    }
}
