using System.Reflection;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public abstract class ConvertedConstructor: ConvertedRoutine, ConvertedConstructorMask_I
	{
		public ConstructorInfo UnderlyingConstructor => Get_UnderlyingConstructor();

		protected abstract ConstructorInfo Get_UnderlyingConstructor();

		// TODO: // turn into extension method
		public override bool IsConstructor() => true;

		// TODO: // turn into extension method
		public override bool IsMethod() => false;
	}
}
