using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
    public interface GenericInstanceApiMask_I
    {
	    ClassApiMask_I Classes { get; }

	    MethodApiMask_I Methods { get; }

	    MethodReference MakeGenericInstanceMethod(InfrastructureModelMask_I model, TypeReference declaringType, MethodReference methodReference, MethodInfo method);

	    
	}
}
