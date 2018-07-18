namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class GenericAndBaseWithThreeGenericParameters<A, B, C>:BaseGeneric<A, B, C>
        where A: Interface1
        where B : Interface2
        where C : Interface3

    {
        public void Execute()
        {
            
        }

        
    }
}
