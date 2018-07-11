using System;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeArguments
{
	public interface BuildingApiMask_I
	{
		Type[] Build(ILConversion conversion, ConvertedGenericTypeDefinition_I converted);
	}
}
