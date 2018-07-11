namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class ArrayTesting_MultipleTypes
    {
        public ArrayTesting_MultipleTypes()
        {
	        var recursive = new ArrayTesting_MultipleTypes[10];

			var x = new Class1[10];

            var y = new Class1[1, 1];

            var z = new [] {new Class1(), new Class1()};

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

			for (int i = 0; i < x.Length; i++)
            {
                x[i] = new Class1();
            }

            y[0, 0] = new Class1();

            z[0] = new Class1();

            z[1] = new Class1();


            var a = new int[10];

            var b = new int[1, 1];

            var c = new[] { 1, 2 };

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }

            b[0, 0] = 1;

            c[0] = 1;

            c[1] = 1;
        }
    }
}
