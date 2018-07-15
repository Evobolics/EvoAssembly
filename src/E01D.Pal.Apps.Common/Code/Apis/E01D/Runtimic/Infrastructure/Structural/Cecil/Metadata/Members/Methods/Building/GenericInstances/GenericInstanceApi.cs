using System;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances
{
	public class GenericInstanceApi<TContainer> : CecilApiNode<TContainer>, GenericInstanceApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	    public ClassApi_I<TContainer> Classes { get; set; }

	    ClassApiMask_I GenericInstanceApiMask_I.Classes => Classes;

	    public new MethodApi_I<TContainer> Methods { get; set; }

	    MethodApiMask_I GenericInstanceApiMask_I.Methods => Methods;

	    public MethodReference MakeGenericInstanceMethod(InfrastructureRuntimicModelMask_I model, TypeReference declaringType, MethodReference methodReference, MethodInfo method)
	    {
		    Type[] typeArguments = method.GetGenericArguments();

		    TypeReference[] typeArgumentReferences = ResolveGenericArguments(model, typeArguments);

		    var resolvedMethodReference = new GenericInstanceMethod(methodReference)
		    {
			    ReturnType = ResolveTypeParameterIfPresent(model, methodReference.ReturnType, typeArgumentReferences),
		    };

		    AddGenericArguments(model, resolvedMethodReference, typeArgumentReferences);

		    for (int i = 0; i < methodReference.Parameters.Count; i++)
		    {
			    var inputParameter = methodReference.Parameters[i];

			    var inputParameterType = inputParameter.ParameterType;

			    var outputParameterType = ResolveTypeParameterIfPresent(model, inputParameterType, typeArgumentReferences);

			    var outputParameter = Parameters.Create(inputParameter, outputParameterType);

			    resolvedMethodReference.Parameters.Add(outputParameter);
		    }

		    return resolvedMethodReference;
	    }

	    private void AddGenericArguments(InfrastructureRuntimicModelMask_I model, GenericInstanceMethod resolvedMethodReference, TypeReference[] typeArgumentReferences)
	    {
		    for (int i = 0; i < typeArgumentReferences.Length; i++)
		    {
			    resolvedMethodReference.GenericArguments.Add(typeArgumentReferences[i]);
		    }
	    }

	    private TypeReference[] ResolveGenericArguments(InfrastructureRuntimicModelMask_I model, Type[] typeArguments)
	    {
		    TypeReference[] references = new TypeReference[typeArguments.Length];

		    for (int i = 0; i < typeArguments.Length; i++)
		    {
			    references[i] = ResolveTypeParameterIfPresent(model, typeArguments[i]);
		    }

		    return references;
	    }

	    public TypeReference ResolveTypeParameterIfPresent(InfrastructureRuntimicModelMask_I model, Type typeToResolve)
	    {
		    if (!typeToResolve.IsGenericParameter)
		    {
			    return Types.Getting.GetInternalTypeReference(model, typeToResolve);
		    }

		    //var x = typeToResolve.GetType();

		    throw new NotImplementedException();
	    }

	    public TypeReference ResolveTypeParameterIfPresent(InfrastructureRuntimicModelMask_I model, TypeReference typeReferenceToResolve, TypeReference[] parametersInOrder)
	    {
		    if (!typeReferenceToResolve.IsGenericParameter) return typeReferenceToResolve;


		    throw new NotImplementedException();
	    }
	}
}
