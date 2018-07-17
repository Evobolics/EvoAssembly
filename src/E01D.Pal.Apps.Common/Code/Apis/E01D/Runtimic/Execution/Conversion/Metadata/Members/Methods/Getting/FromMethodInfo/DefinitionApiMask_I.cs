namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public interface DefinitionApiMask_I
	{
		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.  This method first gets the type definition associated with the 
		/// type reference.
		/// </summary>
		//MethodDefinition GetMethodDefinition(ILConversion conversion, TypeReference typeReference, MethodInfo method, MethodInfo methodFromGenericTypeDefinition);

		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="typeDefinition"></param>
		/// <param name="typeReference"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		//MethodDefinition GetMethodDefinition(MethodReferenceSearch search);
	}
}
