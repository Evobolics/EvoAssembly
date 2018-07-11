using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Getting.FromMethodInfo
{


	public class ReferenceApi<TContainer> : BindingApiNode<TContainer>, ReferenceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		//public MethodReference GetMethodReference(InfrastructureModelMask_I model, TypeReference typeReference, MethodInfo method)
		//{
		//	// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
		//	var typeDefinition = Cecil.Metadata.Members.Types.Getting.GetDefinition(model, typeReference);

		//	return GetMethodReference(model, typeDefinition, method);
		//}

		//public MethodReference GetMethodReference(InfrastructureModelMask_I model, TypeDefinition typeDefinition, MethodInfo method)
		//{
		//	//  DEBUGGING: This is the current issue
		//	var methodDefinition = Methods.Getting.FromMethodInfos.Definitions.GetMethodDefinition(model, typeDefinition, method);

		//	return Cecil.Metadata.Members.Methods.Building.MethodDefinitions.MakeMethodDefinition(model, methodDefinition, method);
		//}
	}
}
