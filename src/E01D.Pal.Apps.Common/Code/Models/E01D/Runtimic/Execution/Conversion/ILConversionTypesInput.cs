using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public class ILConversionTypesInput : ILConversionInput
	{
		public override InputOutputKind Kind { get; } = InputOutputKind.Types;

		public Type[] Types { get; set; }
	}
}
