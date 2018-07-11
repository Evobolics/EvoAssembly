using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public class DefinitionApi<TContainer> : BindingApiNode<TContainer>, DefinitionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		/// <summary>
		/// Gets the method definition that coresponds to the runtime method info.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeDefinition"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		public MethodDefinition GetMethodDefinition(InfrastructureModelMask_I model, TypeDefinition typeDefinition, MethodInfo method)
		{
			var methodDefinitions = typeDefinition.Methods;

			for (int i = 0; i < methodDefinitions.Count; i++)
			{
				var methodDefinition = methodDefinitions[i];

				if (method.MetadataToken == methodDefinition.MetadataToken.ToInt32()) return methodDefinition;
			}

			throw new Exception($"Could not find a method matching the method name {method.Name}.");
		}

		//private bool AreSameMethod(InfrastructureModelMask_I model, MethodInfo method, MethodDefinition methodDefinition)
		//{
			

		//	if (methodDefinition.Name != method.Name) return false;

		//	if (!VerifyGenericArguments(model, methodDefinition, method)) return false;

		//	// Do need - C# operators and CIL can overload methods with jsut return type.
		//	// https://blogs.msdn.microsoft.com/abhinaba/2005/10/07/c-cil-supports-overloading-by-return-type/
		//	if (!VerifyReturnType(model, methodDefinition, method)) return false;

		//	if (!VerifyParameters(model, methodDefinition, method)) return false;

		//	return true;
		//}

		//private bool VerifyReturnType(InfrastructureModelMask_I model, MethodReference currentMethod, MethodInfo targetMethod)
		//{
		//	var currentReturnType = currentMethod.ReturnType;

		//	var targetReturnType = targetMethod.ReturnType;

		//	return VerifyTypeMatch(model, currentReturnType, targetReturnType, targetMethod);


		//}

		//public bool VerifyTypeMatch(InfrastructureModelMask_I model, TypeReference currentTypeReference, Type currentType, MethodInfo method)
		//{
		//	if (currentType.MetadataToken == currentTypeReference.MetadataToken.ToInt32()) return true;

		//	// If one is a generic parameter and one is not, then return false;
		//	if (currentTypeReference.IsGenericParameter != currentType.IsGenericParameter)
		//	{
		//		return false;
		//	}

		//	// If they are just generic parameters, check the name only.
		//	if (currentTypeReference.IsGenericParameter && currentType.IsGenericParameter)
		//	{
		//		return currentTypeReference.Name == currentType.Name;
		//	}

		//	BoundTypeDefinitionMask_I type1;

		//	if (currentTypeReference.IsArray)
		//	{
		//		return VerifyTypeMatch_Array(model, (ArrayType)currentTypeReference, currentType, method);
		//	}
		//	if (currentTypeReference.IsGenericInstance)
		//	{
		//		return VerifyTypeMatch_GenericInstance(model, (GenericInstanceType)currentTypeReference, currentType, method);
				
		//	}

		//	if (currentTypeReference.IsGenericParameter)
		//	{
		//		if (method.GetGenericArguments().Length > 0)
		//		{
		//			throw new System.NotImplementedException();
		//			//type1 = ResolveGenericParameterToArgumentType(model, (GenericParameter) currentTypeReference, method);
		//		}
		//		else
		//		{
		//			throw new System.NotImplementedException();
		//			//type1 = ResolveGenericParameterToParameterType(model, (GenericParameter)currentTypeReference, method);
		//		}
		//	}
		//	else
		//	{
		//		type1 = Types.Ensuring.EnsureBound(model, currentTypeReference, null);
		//	}
			
		//	var	type2 = Types.Ensuring.EnsureBound(model, currentType);

		//	return ReferenceEquals(type1, type2);
		//}

		//private bool VerifyTypeMatch_Array(InfrastructureModelMask_I model, ArrayType currentTypeReference, Type currentType, MethodInfo method)
		//{
		//	var elementTypeReference = currentTypeReference.ElementType;

		//	if (!currentType.HasElementType) return false;

		//	var elementType = currentType.GetElementType();

		//	if (!VerifyTypeMatch(model, elementTypeReference, elementType, method)) return false;

		//	if (!currentTypeReference.IsVector)
		//	{
		//		if (currentTypeReference.Rank != currentType.GetArrayRank()) return false;
		//	}

		//	return true;
		//}

		//private bool VerifyTypeMatch_GenericInstance(InfrastructureModelMask_I model, GenericInstanceType currentTypeReference, Type currentType, MethodInfo method)
		//{
		//	if (!VerifyTypeMatch(model, currentTypeReference.ElementType, currentType.GetGenericTypeDefinition(), method)) return false;

		//	var currentTypeReferenceArguments = currentTypeReference.GenericArguments;

		//	var typeArguments = ((TypeInfo) currentType).GenericTypeArguments;

		//	if (currentTypeReferenceArguments.Count != typeArguments.Length) return false;

		//	for (int i = 0; i < typeArguments.Length; i++)
		//	{
		//		var typeArugument = typeArguments[i];

		//		var typeArgumentReference = (GenericParameter)currentTypeReferenceArguments[i];

		//		if (typeArugument.MetadataToken == typeArgumentReference.MetadataToken.ToInt32()) continue;

		//		if (typeArugument.Name != typeArgumentReference.Name) return false;

		//		if (typeArugument.GenericParameterPosition != typeArgumentReference.Position) return false;

		//		var declaringMethod = typeArugument.DeclaringMethod;

		//		var declaringMethodReference = typeArgumentReference.DeclaringMethod;

		//		if (declaringMethod == null || declaringMethodReference == null) 
		//		{
		//			// Needs to be placed wihtin the if statement, as generic type parameter that has a declaring method
		//			// also has a declaring type if it is a system type.  But this is not the case for cecil types.
		//			if ((typeArugument.DeclaringType == null && typeArgumentReference.DeclaringType != null)
		//			    || (typeArugument.DeclaringType != null && typeArgumentReference.DeclaringType == null)) return false;

		//			if (!VerifyTypeMatch(model, typeArgumentReference.DeclaringType, typeArugument.DeclaringType, method)) return false;
		//		}
		//		else
		//		{
		//			if (declaringMethod.Name != declaringMethodReference.Name) return false;

		//			if (declaringMethod.MetadataToken != declaringMethodReference.MetadataToken.ToInt32()) return false;
					
					
		//		}
		//	}

		//	return true;

		//	//var type1 = Types.Ensuring.EnsureBound(model, currentTypeReference.ElementType, null);

		//	//var type2 = Types.Ensuring.EnsureBound(model, currentType.GetGenericTypeDefinition());

		//	//if (!ReferenceEquals(type1, type2)) return false;
		//}

		//public bool VerifyGenericArguments(InfrastructureModelMask_I model, MethodReference currentMethod, MethodInfo method)
		//{
		//	var genericArugments = method.GetGenericArguments();

		//	var cecilGenericParameters = currentMethod.GenericParameters;

		//	if (genericArugments.Length != cecilGenericParameters.Count) return false;

		//	return true;
		//}

		//public bool VerifyParameters(InfrastructureModelMask_I model, MethodReference currentMethod, MethodInfo method)
		//{
		//	var parameters = method.GetParameters();

		//	var cecilParameters = currentMethod.Parameters;

		//	if (parameters.Length != cecilParameters.Count) return false;

		//	int i = 0;

		//	foreach (var currentParameter in cecilParameters)
		//	{
		//		var parameter = parameters[i];

		//		var parameterType = parameter.ParameterType;

		//		var cecilParameterType = currentParameter.ParameterType;

		//		if (!VerifyTypeMatch(model, cecilParameterType, parameterType, method)) return false;

		//		if (parameter.IsIn != currentParameter.IsIn ||
		//			parameter.IsOut != currentParameter.IsOut ||
		//			parameterType.IsByRef != cecilParameterType.IsByReference)
		//		{
		//			return false;
		//		}

		//		i++;

		//	}

		//	return true;
		//}

		//public BoundTypeDefinitionMask_I ResolveGenericParameterToArgumentType(InfrastructureModelMask_I model, GenericParameter parameter, MethodInfo methodInfo)
		//{
		//	if (parameter.DeclaringType != null)
		//	{
		//		var arguments = methodInfo.DeclaringType.GenericTypeArguments;

		//		var argument = arguments[parameter.Position];

		//		return Types.Ensuring.EnsureBound(model, argument);
		//	}
		//	else
		//	{
		//		var arguments = methodInfo.GetGenericArguments();

		//		var argument = arguments[parameter.Position];

		//		return Types.Ensuring.EnsureBound(model, argument);	
		//	}
		//}

		//public BoundTypeDefinitionMask_I ResolveGenericParameterToParameterType(InfrastructureModelMask_I model, GenericParameter parameter, MethodInfo methodInfo)
		//{
		//	if (parameter.DeclaringType != null)
		//	{
		//		var methodInfoParameters = ((TypeInfo) methodInfo.DeclaringType).GenericTypeParameters;

		//		var methodInfoParameter = methodInfoParameters[parameter.Position];

		//		// By including the parameter and methodInfoParameter 
		//		return Types.Ensuring.EnsureBound(model, parameter, methodInfoParameter);
		//	}
		//	else
		//	{
				

		//		//var arguments = methodInfo.

		//		//var argument = arguments[parameter.Position];

		//		throw new Exception("Not Implemented");
		//		//return Types.Ensuring.EnsureBound(model, argument);	
		//	}
		//}
	}
}
