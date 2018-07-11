using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class PropertyTesting_ClassWithGetProperty
	{
		public object Execute()
		{
			return Message;
		}

		public string Message { get; } = "Howdy";
	}
}
