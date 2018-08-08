namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_BranchTest
	{
		public object Execute()
		{
			int a = 1;
			int b = 1;

			if (a == b)
			{
				return 1;
			}

			return 0;
		}
	}
}
