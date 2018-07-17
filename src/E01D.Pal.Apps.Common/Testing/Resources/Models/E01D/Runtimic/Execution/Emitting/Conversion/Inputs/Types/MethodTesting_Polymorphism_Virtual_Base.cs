namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_Polymorphism_Virtual_Base
	{
		public virtual object SayHi()
		{
			return "Nope!";
		}

		public virtual string SayHello()
		{
			return "Hello";
		}
	}
}
