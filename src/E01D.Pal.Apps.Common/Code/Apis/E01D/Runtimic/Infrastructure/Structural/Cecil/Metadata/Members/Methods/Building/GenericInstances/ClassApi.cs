using System;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
	public class ClassApi<TContainer> : CecilApiNode<TContainer>, ClassApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public MethodReference MakeGenericInstanceMethod(InfrastructureModelMask_I model, TypeReference typeReference,
			TypeDefinition typeDefinition, MethodReference methodReference, MethodInfo method)
		{
			throw new NotImplementedException();
		}
	}
}
