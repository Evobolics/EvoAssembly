using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo
{


	public class ReferenceApi<TContainer> : CecilApiNode<TContainer>, ReferenceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		public MethodReference GetMethodReference(InfrastructureModelMask_I model, TypeReference typeReference, ConstructorInfo method)
		{
			// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
			var typeDefinition = Types.Getting.GetDefinition(model, typeReference);

			return GetMethodReference(model, typeDefinition, method);
		}

		public MethodReference GetMethodReference(InfrastructureModelMask_I model, TypeDefinition typeDefinition, ConstructorInfo method)
		{
			//  DEBUGGING: This is the current issue
			var methodDefinition = this.Constructors.Getting.FromConstructorInfos.Definitions.GetMethodDefinition(model, typeDefinition, method);

			return Methods.Building.MethodDefinitions.MakeGenericInstanceTypeMethodReference(model, methodDefinition, method.DeclaringType);
		}


	}
}
