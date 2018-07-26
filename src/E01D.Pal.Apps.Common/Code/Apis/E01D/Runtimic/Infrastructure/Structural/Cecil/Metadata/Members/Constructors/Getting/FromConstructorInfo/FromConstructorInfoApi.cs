using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo
{
	public class FromConstructorInfoApi<TContainer> : CecilApiNode<TContainer>, FromConstructorInfoApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{


		///// <summary>
		///// Gets the method definition that coresponds to the runtime method info.
		///// </summary>
		///// <param name="model"></param>
		///// <param name="typeReference"></param>
		///// <param name="method"></param>
		///// <returns></returns>
		///// <summary>
		///// Gets the method definition that is associated with the MethodInfo.  This method first gets the type definition associated with the 
		///// type reference.
		///// </summary>
		//public MethodDefinition GetMethodDefinition(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, ConstructorInfo method)
		//{
		//	// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
		//	var typeDefinition = Types.Getting.GetDefinition(model, typeReference);

		//	return GetMethodDefinition(model, typeDefinition, method);
		//}

		

		//public MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, ConstructorInfo method)
		//{
		//	// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
		//	var typeDefinition = Types.Getting.GetDefinition(model, typeReference);

		//	return GetMethodReference(model, typeDefinition, method);
		//}

		//public MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model, Collection<MethodDefinition> methods, Type memberDeclaringType, int methodMetadataToken)
		//{
		//	Methods.Getting.GetMethodReference(model, methods, memberDeclaringType, methodMetadataToken);

		//	if (memberDeclaringType.Module.Assembly.IsDynamic)
		//		throw new Exception("Cannot be used for methods that orginate from dynamic assemblies as the metadata tokens will not match.");

		//	var methodDefinition = Methods.Getting.GetMethodDefinition(model, methods, methodMetadataToken);

		//	if (memberDeclaringType == null) return methodDefinition;

		//	Type[] typeArguments = memberDeclaringType.GenericTypeArguments;

		//	if (typeArguments == null || typeArguments.Length < 1) return methodDefinition;

		//	return Methods.Building.MethodDefinitions.MakeGenericInstanceTypeMethodReference(model, methodDefinition, memberDeclaringType, typeArguments);
		//}

		


	}
}
