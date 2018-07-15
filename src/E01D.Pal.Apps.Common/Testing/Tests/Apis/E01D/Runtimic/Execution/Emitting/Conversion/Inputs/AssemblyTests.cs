using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Attributes.E01D;
using Root.Code.Exts.Runtimic;
using Root.Code.Shortcuts.E01D;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class AssemblyTests
	{
		[Test]
		public void Convert_EvoPalAppsCommon()
		{
			// 1) Create a conversion container
			var container = EvoAssembly.CreateContainer();

			// 2) Create a conversion container
			var collectibleAssembly = container.Convert(typeof(AssemblyTests).Assembly);
		}
	}
}
