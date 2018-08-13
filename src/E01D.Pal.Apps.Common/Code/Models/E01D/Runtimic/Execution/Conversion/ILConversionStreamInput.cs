using System.IO;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public class ILConversionStreamInput: ILConversionInput
	{
		public override InputOutputKind Kind { get; } = InputOutputKind.Streams;

		//public Stream[] Streams { get; set; }
	}
}
