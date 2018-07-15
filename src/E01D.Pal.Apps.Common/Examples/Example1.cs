using System;
using Root.Code.PI.E01D;

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

			// Example3: Convert an array of types
			var convertedTypes = EvoAssembly.QuickConvert(new Type[]{typeof(Example1)});

			// Example4: Convert an array of assemblies
			var convertedAssemblies = EvoAssembly.QuickConvert(new []{typeof(Example1).Assembly});
		}
	}
}
