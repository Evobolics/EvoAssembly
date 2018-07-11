using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public class TypeApi<TContainer> : BindingApiNode<TContainer>, TypeApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		/// <summary>
		/// Converts the specified types to a collectible assembly.  All dependent types should be included.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="inputTypes"></param>
		//public ILConversionResult Convert(ILConversion conversion, Type[] inputTypes)
		//{
		//	var convertedAssembly = Conversion.Assemblies.Creation.CreateConvertedAssembly(conversion);

		//    var convertedModule = convertedAssembly.Modules.Values.SingleOrDefault() as ConvertedModule;

		//    if (convertedModule == null)
		//    {
		//        throw new Exception("Expected single converted module.");
		//    }

		//	Conversion.Modules.Convert(convertedModule, inputTypes);

		//	return conversion.Result;
		//}
	}
}
