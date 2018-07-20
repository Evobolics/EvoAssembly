using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Code.Domains.E01D;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class MethodTests
	{
		[Test]
		public void MethodTesting_Polymorphism_Virtual()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var type = test.Api.ConvertSingleType(typeof(MethodTesting_Polymorphism_Virtual));

			//var baseType = type.BaseType;

			//var constructor = type.GetConstructor(Type.EmptyTypes);

			//var instance = constructor.Invoke(new object[]{});

			//var baseInstance = Convert.ChangeType(instance, baseType);

			//var method = baseType.GetMethod("Execute");

			//var result1 = method.Invoke(instance, new object[] { });

			//Assert.AreEqual("Howdy", (string)result1);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_Polymorphism_Virtual), "Execute");

			Assert.AreEqual("Howdy", (string)result2);



		}

		[Test]
		public void MethodTesting_ExplicitInterfaceImplementation()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_ExplicitInterfaceImplementation), "Execute");

			Assert.AreEqual("Done", (string)result2);



		}

		[Test]
		public void MethodTesting_CallGenericDelegate()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_CallGenericDelegate), "Execute");

			Assert.AreEqual("Howdy", (string)result2);



		}

		[Test]
		public void MethodTesting_CallGenericInstanceMethod()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_CallGenericInstanceMethod<object>), "Execute");

			



		}

		[Test]
		public void MethodTesting_CallGenericInstanceMethodTypeArgumentInMethodSignature()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_CallGenericInstanceMethodTypeArgumentInMethodSignature<object>), "Execute");





		}

		[Test]
		public void MethodTesting_FindConstructorBeforeCreated()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_FindConstructorBeforeCreatedA), "Execute");





		}

		[Test]
		public void MethodTesting_FindMethodBeforeCreated()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_FindMethodBeforeCreatedA), "Execute");





		}

		[Test]
		public void MethodTesting_DictionaryTryGet()
		{
			// Create a test container
			var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

			var result2 = test.Api.ConvertCreateCall(typeof(MethodTesting_DictionaryTryGet), "Execute");





		}
	}
}
