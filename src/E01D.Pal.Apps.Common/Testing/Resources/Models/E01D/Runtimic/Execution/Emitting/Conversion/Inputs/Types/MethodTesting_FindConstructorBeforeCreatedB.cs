using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_FindConstructorBeforeCreatedB
	{
		public void Execute()
		{
			MethodTesting_FindConstructorBeforeCreatedA a = new MethodTesting_FindConstructorBeforeCreatedA();

			a.Execute2();
		}
	}
}
