namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ClassTesting_LocalsViaAddition
	{
		public int Result;

		public ClassTesting_LocalsViaAddition()
		{
			int a = 1;
			int b = 1;
			int c = a + b;

			Result = c;
		}
	}
}
