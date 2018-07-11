namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ClassWithMethod_OutParameter
	{
		public object Execute()
		{
			int i = 2;

			AddIt(i, i, out int result);

			return result;
		}

		public void AddIt(int a, int b, out  int result)
		{
			result = a + b;
		}
	}
}
