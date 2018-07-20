using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodReference
{
	public interface FromMethodReferenceApiMask_I
	{
		MethodInfo Get(ILConversion conversion, MethodReference methodReference, MethodInfo[] getMethods);
	}
}
