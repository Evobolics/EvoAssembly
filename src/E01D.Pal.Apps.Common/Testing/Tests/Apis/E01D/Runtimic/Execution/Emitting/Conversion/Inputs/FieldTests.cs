using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Code.Domains.E01D;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class FieldTests
	{
		[Test]
		public void FieldTest_TypeBuilderGetFieldIsWorking()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			// Convert the type. This test will verify that the TypeBuilder.GetConstructor() call is working correctly.  The method should
			// fail to produce correct IL if TypeBuilder.GetConstructor() is not called.  The GetConstructor is needed because the Execute() method
			// creates a generic instance of GenericClassWithGenericFields<string, T>() that passes a type parameter from the class to the generic
			// instance being created as a type argument.  This should not be possible without the aide of the TypeBuilder.GetConstructor() call.
			// The converter code should make the following call somewhere in the code:

			//		var returnTypeWithString = returnType2.MakeGenericType(typeof(string), mainTypeGenericParameterType1);

			//		var returnTypeWithStringCtor = TypeBuilder.GetConstructor(returnTypeWithString, returnTypeCtor);

			//		var mainTypeReturnTypeField1 = TypeBuilder.GetField(returnTypeWithString, returnTypeField1);

			//		var mainTypeReturnTypeField2 = TypeBuilder.GetField(returnTypeWithString, returnTypeField2);

			var result = test.Api.ConvertCreateCall(typeof(FieldTest_TypeBuilderGetFieldIsWorking<object>), "Execute");


		}
	}
}
