using System.Reflection.Emit;
using Root.Code.Attributes.E01D;
using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class ClassTests_NoILGenerator
	{
		[Test]
		public void CanCreateBareBonesClass()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertSingleType(typeof(SimpleClass), new ILConversionOptions()
			{
				BuilderAccess = AssemblyBuilderAccess.RunAndCollect,
				UseILGenerator = false
			});




		}

		[Test]
		public void CanCreateAndInstigateBareBonesClass()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var instance = test.Api.ConvertAndCreateInstance(typeof(SimpleClass), new ILConversionOptions()
			{
				BuilderAccess =  AssemblyBuilderAccess.RunAndCollect,
				UseILGenerator = false
			});




		}
	}
}
