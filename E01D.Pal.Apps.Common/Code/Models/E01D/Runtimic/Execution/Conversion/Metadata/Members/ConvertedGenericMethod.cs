using System.Reflection;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	/// <summary>
	/// Represents a method that orginated from a generic instance.  These methods do not have method builders
	/// as the methodinfos require the generic arguments be put in place, and a generic instance to be created.
	/// </summary>
	public class ConvertedGenericMethod : ConvertedMethod, ConvertedGenericInstanceMethod_I
	{
		public new MethodInfo UnderlyingMethod { get; set; }
		protected override MethodInfo UnderlyingMethod_Get()
		{
			return UnderlyingMethod;
		}
	}
}
