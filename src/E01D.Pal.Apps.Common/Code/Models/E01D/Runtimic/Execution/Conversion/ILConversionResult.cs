using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public class ILConversionResult
    {
	    public List<System.Exception> Exceptions { get; set; } = new List<System.Exception>();


		public ILConversionOutput Output { get; set; }

	    

    }
}
