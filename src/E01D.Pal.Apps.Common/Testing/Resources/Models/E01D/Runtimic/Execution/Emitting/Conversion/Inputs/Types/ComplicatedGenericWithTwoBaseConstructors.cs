namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class ComplicatedGenericWithTwoBaseConstructors<A, B, C> : BaseGenericWithTwoConstructors<A, B, C>
        where A : Interface1
        where B : Interface2
        where C : Interface3

    {
        public ComplicatedGenericWithTwoBaseConstructors()
        {

        }

        public ComplicatedGenericWithTwoBaseConstructors(string testMessage, string x)
            : base(testMessage)
        {

        }

        public void Execute()
        {

        }


    }
    
    
}
