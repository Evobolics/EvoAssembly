namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	                                                              //  not supported when you try to load the properties in a dynamic assembly
	[Custom1("Howdy", new []{ EnumTesting_BasicEnum_Int16.One})]  //  MyField1 = new[] { EnumTesting_BasicEnum_Int16.One }, MyField2 = typeof(Custom1Attribute), MyProperty1 =1 
																  // https://github.com/dotnet/core/issues/1481
	public class ClassTesting_ClassWithBlankAttribute
	{
	}
}
