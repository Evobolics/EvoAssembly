namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ClassWithMethod_RefParameter
	{
		public object Execute()
		{
			int i = 2;

			DoubleIt(ref i);

			return i;
		}

		public void DoubleIt(ref int a)
		{
			a *= 2;
		}
	}
}
