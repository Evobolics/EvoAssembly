using System.Reflection;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public class ILConversionAssembliesInput : ILConversionInput
	{
		public override InputOutputKind Kind { get; } = InputOutputKind.Assemblies;

		public Assembly[] Assemblies { get; set; }
	}
}