using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class PropertyTests
	{
		[Test]
		public void PropertyTesting_ClassWithGetProperty()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(PropertyTesting_ClassWithGetProperty));

			var type = instance.GetType();

			var property = type.GetProperty("Message");

			Assert.IsNotNull(property);
			Assert.IsTrue(property.CanRead);
			Assert.IsFalse(property.CanWrite);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var result = test.Api.ConvertCreateCall(typeof(PropertyTesting_ClassWithGetProperty), "Execute");

			Assert.AreEqual("Howdy", (string)result);


		}

		[Test]
		public void PropertyTesting_ClassWithSetProperty()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(PropertyTesting_ClassWithSetProperty));

			var type = instance.GetType();

			var property = type.GetProperty("Message");

			Assert.IsNotNull(property);
			Assert.IsFalse(property.CanRead);
			Assert.IsTrue(property.CanWrite);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var result = test.Api.ConvertCreateCall(typeof(PropertyTesting_ClassWithSetProperty), "Execute");

			Assert.AreEqual("Howdy", (string)result);


		}

		[Test]
		public void PropertyTesting_ClassWithGetSetProperty()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(PropertyTesting_ClassWithGetSetProperty));

			var type = instance.GetType();

			var property = type.GetProperty("Message");

			Assert.IsNotNull(property);
			Assert.IsTrue(property.CanRead);
			Assert.IsTrue(property.CanWrite);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var result = test.Api.ConvertCreateCall(typeof(PropertyTesting_ClassWithGetSetProperty), "Execute");

			Assert.AreEqual("Howdy", (string)result);


		}
	}
}
