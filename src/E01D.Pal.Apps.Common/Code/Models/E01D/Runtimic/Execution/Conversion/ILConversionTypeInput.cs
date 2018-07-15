using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public class ILConversionTypeInput: ILConversionInput
	{
		

		public override InputOutputKind Kind { get; } = InputOutputKind.Type;

		public Type Type { get; set; }
	}
}
