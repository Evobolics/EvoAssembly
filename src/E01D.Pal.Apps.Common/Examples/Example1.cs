using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Exts.Runtimic;
using Root.Code.Shortcuts.E01D;

namespace Root.Examples
{
	public class Example1
	{
		public void Perform()
		{
			// Example1: Convert a type
			var convertedType = EvoAssembly.QuickConvert(typeof(Example1));

			// Example2: Convert an assembly
			var convertedAssembly = EvoAssembly.QuickConvert(typeof(Example1).Assembly);
		}
	}
}
