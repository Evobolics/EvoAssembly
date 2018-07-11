using System.Reflection;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public class ConvertedBoundMethod : ConvertedMethod, ConvertedGenericInstanceMethod_I
	{
		public new MethodInfo UnderlyingMethod { get; set; }
		protected override MethodInfo UnderlyingMethod_Get()
		{
			return UnderlyingMethod;
		}
	}
}
