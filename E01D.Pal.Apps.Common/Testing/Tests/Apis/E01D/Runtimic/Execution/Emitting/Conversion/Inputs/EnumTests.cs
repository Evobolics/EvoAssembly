using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class EnumTests
	{
		[Test]
		public void EnumTesting_CreateBlankEnum()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var enumType = test.Api.ConvertSingleType(typeof(EnumTesting_BlankEnum));

			var enumValues = enumType.GetEnumValues();
		}

		[Test]
		public void EnumTesting_CreateBasicEnum_Int32()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var enumType = test.Api.ConvertSingleType(typeof(EnumTesting_BasicEnum_Int32));

			var enumValues = enumType.GetEnumValues();
		}

		[Test]
		public void EnumTesting_CreateBasicEnum_Int16()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var enumType = test.Api.ConvertSingleType(typeof(EnumTesting_BasicEnum_Int16));

			var enumValues = enumType.GetEnumValues();
		}

		[Test]
		public void EnumTesting_NestedEnum()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var parentType = test.Api.ConvertSingleType(typeof(EnumTesting_NestedEnum));

			var enumType = parentType.GetNestedType("EnumTesting_NestedEnum/NestedEnum");

			var enumValues = enumType.GetEnumValues();
		}

		[Test]
		public void EnumTesting_NestedEnum_NoValues()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var parentType = test.Api.ConvertSingleType(typeof(EnumTesting_NestedEnum_NoValues));

			var enumType = parentType.GetNestedType("EnumTesting_NestedEnum_NoValues/NestedEnum");

			var enumValues = enumType.GetEnumValues();
		}
	}
}
