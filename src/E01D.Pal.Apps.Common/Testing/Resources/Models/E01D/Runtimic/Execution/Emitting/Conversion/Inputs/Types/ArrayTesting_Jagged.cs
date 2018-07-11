namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ArrayTesting_Jagged
	{
		public void Execute()
		{
			var d = new int[10][];

			for (int i = 0; i < d.Length; i++)
			{
				d[i] = new int[10];

				for (int j = 0; j < d[i].Length; j++)
				{
					d[i][j] = 1;

					var abc = d[i][j];

					d[i][j] = abc;
				}
			}
		}
	}
}
