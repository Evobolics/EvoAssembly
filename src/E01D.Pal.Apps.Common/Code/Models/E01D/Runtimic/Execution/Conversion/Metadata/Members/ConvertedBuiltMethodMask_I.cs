using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public interface ConvertedBuiltMethodMask_I: ConvertedMethodMask_I
	{
		MethodBuilder MethodBuilder { get; }

		ILGenerator IlGenerator { get; }
	}
}
