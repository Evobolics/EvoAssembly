namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_TwoMethodsNamedTheSame_DifferentGenericArgumentLength<T>
	{
		public int Execute()
		{
			var x = Add<T>(1, 1);

			x += Add<T, T>(1, 1);

			return x;
		}

		public int Add<M1>(int a, int b)
		{
			return a + b;
		}

		public int Add<M1, M2>(int a, int b)
		{
			return a + b + 1;
		}
	}
}
