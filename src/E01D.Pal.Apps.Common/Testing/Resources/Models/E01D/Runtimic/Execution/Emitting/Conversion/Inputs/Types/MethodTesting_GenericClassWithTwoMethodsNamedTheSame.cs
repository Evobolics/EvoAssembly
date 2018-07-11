namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_GenericClassWithTwoMethodsNamedTheSame<T>
	{
		public int Execute()
		{
			var x = Add(1, 1);

			x += Add(1, 1, 1);

			return x;
		}

		public int Add(int a, int b)
		{
			return a + b;
		}

		public int Add(int a, int b, int c)
		{
			return a + b + c;
		}
	}
}
