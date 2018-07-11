using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Code.Domains.E01D;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class EventTests
	{
		[Test]
		public void EventTesting_BasicEvent()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(EventTesting_BasicEvent));

			var type = instance.GetType();

			var event1 = type.GetEvent("MessageSet");

			Assert.IsNotNull(event1);
			

			// Convert the type. The test api code will check to make sure the instance is not null.
			var result = test.Api.ConvertCreateCall(typeof(EventTesting_BasicEvent), "Execute");

			Assert.AreEqual("Howdy", (string)result);


		}


	
	}
}
