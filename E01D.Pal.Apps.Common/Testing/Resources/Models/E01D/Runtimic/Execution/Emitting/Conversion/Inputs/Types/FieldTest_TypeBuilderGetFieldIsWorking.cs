namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	/// <summary>
	/// This test helps make sure that the use of TypeBuilder.GetField is working and is being used correctly.  
	/// </summary>
	public class FieldTest_TypeBuilderGetFieldIsWorking<T>
	{
		public void Execute()
		{
			// This line of code tests TypeBuilder.GetConstructor()
			new GenericClassWithGenericFields<string, T>()
			{
				// This line of code tests TypeBuilder.GetField()
				Field1 = string.Empty,
				// This line of code tests TypeBuilder.GetField()
				Field2 = default(T)
			};
		}
	}
}
