using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Domains;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class MethodTesting_ExplicitInterfaceImplementation:Aggie_I
	{
		public object Execute()
		{
			string message = SayHello();

			Assert.AreEqual("Hi", message);

			var aggie = (Aggie_I) this;

			message = aggie.SayHello();

			Assert.AreEqual("Howdy", message);

			return "Done";
		}


		public string SayHello()
		{
			return "Hi";
		}

		string Aggie_I.SayHello()
		{
			return "Howdy";
		}
	}
}
