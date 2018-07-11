namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ConstructorTest_TypeBuilderGetConstructorIsWorking<T>
	{
		public void Execute()
		{
			new GenericClassWithGenericFields<string, T>()
			{
				
			};
		}
	}
}
