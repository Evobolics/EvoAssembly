using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class ArrayTests
	{
		[Test]
		public void ArrayTesting_MultipleTypes()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(ArrayTesting_MultipleTypes));

			Assert.IsNotNull(instance);
		}

		[Test]
		public void ArrayTesting_Multidimensional()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(ArrayTesting_Multidimensional));

			Assert.IsNotNull(instance);
		}

		[Test]
		public void ArrayTesting_Jagged()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(ArrayTesting_Jagged));

			Assert.IsNotNull(instance);
		}
	}
}
