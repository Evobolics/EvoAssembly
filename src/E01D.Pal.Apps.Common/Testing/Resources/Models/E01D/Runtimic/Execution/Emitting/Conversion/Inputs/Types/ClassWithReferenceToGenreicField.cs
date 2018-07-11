namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class ClassWithReferenceToGenreicField
    {
        public ClassWithReferenceToGenreicField()
        {
            
        }

        public object Execute()
        {
			

	        var x = new GenericClassWithGenericField<string>()
	        {
	            GenericField = "Howdy"
	        };

			return x.GenericField;
			
        }
    }
}
