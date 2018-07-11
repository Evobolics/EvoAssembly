using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodInfo
{


	public class ReferenceApi<TContainer> : ConversionApiNode<TContainer>, ReferenceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		//public MethodReference GetMethodReference(ILConversion conversion, TypeDefinition declaringTypeDefinition, MethodInfo method)
		//{
		//	var methodDefinition = Methods.Getting.FromMethodInfos.Definitions.GetMethodDefinition(conversion, declaringTypeDefinition, method);

		//	return Cecil.Metadata.Members.Methods.Building.MethodDefinitions.MakeGenericInstanceMethodReference(conversion.Model, methodDefinition, method);
		//}

		
	}
}
