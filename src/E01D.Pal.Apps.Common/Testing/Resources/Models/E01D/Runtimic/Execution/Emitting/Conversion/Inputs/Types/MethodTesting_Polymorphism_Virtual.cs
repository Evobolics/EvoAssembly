using Root.Code.Domains;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_Polymorphism_Virtual: MethodTesting_Polymorphism_Virtual_Base
	{
		public object Execute()
		{
			var thisAsBase = (MethodTesting_Polymorphism_Virtual_Base) this;

		    Assert.AreEqual("Hello", thisAsBase.SayHello());

			Assert.AreEqual("Howdy", this.SayHello());

			return thisAsBase.SayHi();
		}

		public override object SayHi()
		{
			return "Howdy";
		}

		public new string SayHello()
		{
			return "Howdy";
		}

	}
}
