namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_FindMethodBeforeCreatedA
	{
		public MethodTesting_FindMethodBeforeCreatedB Field; // needed to derail ensure path.

		public MethodTesting_FindMethodBeforeCreatedA()
		{
			
		}

		public void Execute()
		{
			MethodTesting_FindMethodBeforeCreatedB.Execute();
		}

		public static void Execute2()
		{
			
		}
	}
}
