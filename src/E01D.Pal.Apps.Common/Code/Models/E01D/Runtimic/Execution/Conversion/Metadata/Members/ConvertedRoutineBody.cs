using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public class ConvertedRoutineBody
	{
		/// <summary>
		/// Gets or sets a list of all the local variables declared in the body.
		/// </summary>
		public List<ConvertedRoutineLocalVariable> LocalVariables { get; set; }
	}
}
