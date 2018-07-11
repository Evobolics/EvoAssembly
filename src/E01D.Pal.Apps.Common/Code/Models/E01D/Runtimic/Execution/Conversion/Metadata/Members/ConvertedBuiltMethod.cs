using System.Reflection;
using System.Reflection.Emit;


namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	/// <summary>
	/// Represents a converted method that is built and has a method builder associated with it.
	/// </summary>
    public class ConvertedBuiltMethod: ConvertedMethod, ConvertedBuiltMethod_I
    {
	    public MethodBuilder MethodBuilder { get; set; }

		protected override MethodInfo UnderlyingMethod_Get()
		{
			return MethodBuilder;
		}







	}
}
