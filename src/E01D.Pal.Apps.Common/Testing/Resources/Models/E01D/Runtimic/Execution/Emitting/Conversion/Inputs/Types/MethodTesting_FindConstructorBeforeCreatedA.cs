using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_FindConstructorBeforeCreatedA
	{
		public MethodTesting_FindConstructorBeforeCreatedB Field;

		public MethodTesting_FindConstructorBeforeCreatedA()
		{
			
		}

		public void Execute()
		{
			Field = new MethodTesting_FindConstructorBeforeCreatedB();

			Field.Execute();
		}

		public void Execute2()
		{
			
		}
	}
}
