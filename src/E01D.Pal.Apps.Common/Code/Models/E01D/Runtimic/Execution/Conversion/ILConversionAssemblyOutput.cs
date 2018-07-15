using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public class ILConversionAssemblyOutput : ILConversionOutput
	{
		public override InputOutputKind Kind { get; } = InputOutputKind.Assembly;

		public Assembly Assembly { get; set; }
	}
}
