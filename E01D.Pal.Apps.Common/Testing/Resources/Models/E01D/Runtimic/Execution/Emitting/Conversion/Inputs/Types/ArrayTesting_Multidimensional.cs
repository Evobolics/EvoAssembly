namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ArrayTesting_Multidimensional
	{
		public object Execute()
		{
			var y = new ArrayTesting_Multidimensional[1, 1];

			var x = new int[1, 1];

			var z = new int[1, 1, 2];

			y.SetValue(new ArrayTesting_Multidimensional(), 0, 0);

			y.SetValue(new ArrayTesting_Multidimensional(), new int[]{0,0});

			return new ArrayTesting_Multidimensional[1, 1, 2];
		}
	}
}
