using System.Reflection;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public abstract class ILConversionOutput
	{
		public Assembly[] Assemblies { get; set; }

		public abstract InputOutputKind Kind { get; }
	}
}
