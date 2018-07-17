using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_CallGenericDelegate
	{
		private string result;

		public object Execute()
		{
			Action<string> action = Do;

			action("Howdy");

			return result;
		}

		public void Do(string message)
		{
			result = message;

			
		}
	}
}
