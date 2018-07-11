namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class BaseGenericWithOneArgConstructor<A, B, C>
    {
        

        public BaseGenericWithOneArgConstructor(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
