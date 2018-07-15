using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting.FromMethodInfo
{


	public class ReferenceApi<TContainer> : CecilApiNode<TContainer>, ReferenceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		public MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, MethodInfo method)
		{
			// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
			var typeDefinition = Types.Getting.GetDefinition(model, typeReference);

			return GetMethodReference(model, typeDefinition, method);
		}

		public MethodReference GetMethodReference(InfrastructureRuntimicModelMask_I model, TypeDefinition typeDefinition, MethodInfo method)
		{
			//  DEBUGGING: This is the current issue
			var methodDefinition = Methods.Getting.FromMethodInfos.Definitions.GetMethodDefinition(model, typeDefinition, method);

			return Methods.Building.MethodDefinitions.MakeGenericInstanceTypeMethodReference(model, methodDefinition, method.DeclaringType);
		}


	}
}
