using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_FindMethodBeforeCreatedA
	{
		public MethodTesting_FindMethodBeforeCreatedB Field;

		public MethodTesting_FindMethodBeforeCreatedA()
		{
			Field = new MethodTesting_FindMethodBeforeCreatedB();

			Field.Execute();
		}

		public void Execute()
		{
			
		}
	}
}
