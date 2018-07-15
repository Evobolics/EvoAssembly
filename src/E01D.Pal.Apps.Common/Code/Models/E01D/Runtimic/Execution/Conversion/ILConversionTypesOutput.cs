using System;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public class ILConversionTypesOutput: ILConversionOutput
	{
		public override InputOutputKind Kind { get; } = InputOutputKind.Types;

		public Type[] Types { get; set; }
	}
}
