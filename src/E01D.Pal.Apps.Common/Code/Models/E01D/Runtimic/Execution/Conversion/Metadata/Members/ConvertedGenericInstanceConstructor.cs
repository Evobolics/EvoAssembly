using System.Reflection;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	/// <summary>
	/// Represents a contructor that came from converted class.
	/// </summary>
	public class ConvertedGenericInstanceConstructor : ConvertedConstructor
	{
		public bool IsInstanceConstructor { get; set; }

		

		public new ConstructorInfo UnderlyingConstructor { get; set; }

		protected override ConstructorInfo Get_UnderlyingConstructor() => UnderlyingConstructor;

		public override MemberInfo UnderlyingMember => UnderlyingConstructor;
	}
}