using System;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{
	public interface InitializationApiMask_I
	{
		void ProcessInputs(ILConversion conversion);

		void ProcessInput(ILConversion conversion, Type type);
	}
}
