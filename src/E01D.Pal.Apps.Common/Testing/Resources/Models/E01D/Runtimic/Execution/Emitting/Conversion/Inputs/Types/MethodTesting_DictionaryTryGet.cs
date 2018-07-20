using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_DictionaryTryGet
	{
		public void Execute()
		{
			Dictionary<string, string> apples = new Dictionary<string, string>();

			apples.TryGetValue(string.Empty, out string somePossibleValue);
		}
	}
}
