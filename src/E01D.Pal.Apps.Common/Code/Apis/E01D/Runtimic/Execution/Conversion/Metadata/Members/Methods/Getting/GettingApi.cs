using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodReference;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting
{
    public class GettingApi<TContainer> : ConversionApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    

	    public FromMethodReferenceApi_I<TContainer> FromMethodReference { get; set; }

	    FromMethodReferenceApiMask_I GettingApiMask_I.FromMethodReference => FromMethodReference;

	    public MethodInfo[] GetMethodInfos(BoundTypeDefinitionMask_I inputBlueprint)
	    {
		    var methodEntries = GetMethods(inputBlueprint);

			var methods = new MethodInfo[methodEntries.Count];

		    for (int i = 0; i < methodEntries.Count; i++)
		    {
			    methods[i] = methodEntries[i].UnderlyingMethod;
		    }

		    return methods;
	    }

	   

		public List<BoundMethodDefinitionMask_I> GetMethods(BoundTypeDefinitionMask_I inputBlueprint)
	    {
		    if (!(inputBlueprint is BoundTypeDefinitionWithMethodsMask_I withMethods))
		    {
			    throw new System.Exception("GenericClassDefinition should have methods if this type has methods.");
		    }

		    var collection = withMethods.Methods.ByName.Values.ToList();

		    List<BoundMethodDefinitionMask_I> methods = new List<BoundMethodDefinitionMask_I>();

		    for (int i = 0; i < collection.Count; i++)
		    {
			    var semanticList = collection[i];

			    for (int j = 0; j < semanticList.Count; j++)
			    {
				    var semantic = semanticList[j];

				    if (!(semantic is BoundMethodDefinitionMask_I bound))
				    {
					    throw new System.Exception("Semantic method should be a bound method to use it in conversion.");
				    }

				    methods.Add(bound);
			    }


		    }

		    return methods;
	    }

	    public BoundMethodDefinitionMask_I GetBoundMethod(ILConversionRuntimicModel conversionModel, BoundModuleMask_I module, MethodInfo genericTypeDefinitionMethodInfo)
	    {
		    if (!module.MethodsByMetadataToken.TryGetValue(genericTypeDefinitionMethodInfo.MetadataToken, out BoundMethodDefinitionMask_I method))
		    {
			    throw new System.Exception("Could not find method");
		    }

		    return method;

	    }

	    public MethodInfo GetMethodInfoOrThrow(ILConversion conversion, ConvertedTypeDefinition_I typeBeingBuilt, MethodReference methodReference)
	    {

		    var declaringType = Execution.Types.Ensuring.EnsureBound(conversion, methodReference.DeclaringType);

		    if (!(declaringType is BoundTypeDefinitionWithMethodsMask_I declaringTypeWithMethods))
		    {
			    throw new System.Exception("Expected a type with methods declared.");
		    }

		    var methodInfo = GetMethodOrThrow_Internal(conversion, typeBeingBuilt, declaringTypeWithMethods, methodReference);

		    if (methodInfo == null)
		    {
			    throw new System.Exception("Could not locate a MethodInfo.");
		    }

		    if (!methodReference.IsGenericInstance) return methodInfo;

		    if (!methodInfo.IsGenericMethod)
		    {
			    throw new System.Exception("Did not find a generic method");
		    }

		    var genericInstanceMethod = (GenericInstanceMethod)methodReference;

		    var typeArguments = new Type[genericInstanceMethod.GenericArguments.Count];

		    for (var i = 0; i < typeArguments.Length; i++)
		    {
			    var typeArgumentReference = genericInstanceMethod.GenericArguments[i];

			    var semanticType = Execution.Types.Ensuring.Ensure(conversion.Model, typeArgumentReference, null, null);

			    if (!(semanticType is BoundTypeDefinitionMask_I bound))
			    {
				    throw new System.Exception("Semantic type needs to be a bound type.");
			    }

			    typeArguments[i] = bound.UnderlyingType;
		    }

		    return methodInfo.MakeGenericMethod(typeArguments);

	    }

	    public ConvertedMethodMask_I GetMethod(ConvertedTypeDefinition_I convertedType, MethodDefinition methodDefinition)
	    {
			if (!(convertedType is ConvertedTypeDefinitionWithMethods_I withMethods))
		    {
			    throw new System.Exception("Expecting a type with methods.");
		    }

		    var collection = withMethods.Methods.ByName.Values.ToList();

		    for (int i = 0; i < collection.Count; i++)
		    {
			    var semanticList = collection[i];

			    for (int j = 0; j < semanticList.Count; j++)
			    {
				    var semantic = semanticList[j];

				    if (!(semantic is ConvertedMethod bound))
				    {
					    continue;
				    }

				    if (object.ReferenceEquals(bound.MethodReference, methodDefinition))
				    {
					    return bound;
				    }
			    }


		    }

		    return null;
	    }

	    public MethodInfo GetMethodOrThrow_Internal(ILConversion conversion, ConvertedTypeDefinition_I callingType, 
			BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods, MethodReference methodReference)
	    {
		    if (boundTypeWithMethods.IsArrayType())
		    {
				return Methods.Building.MakeArrayMethod(conversion, callingType, boundTypeWithMethods, methodReference);
			}

		    if (!boundTypeWithMethods.Methods.ByName.TryGetValue(methodReference.Name, out List<SemanticMethodMask_I> list))
		    {
			    throw new Exception($"Could not find the method {methodReference.FullName}.");
		    }

		    if (list.Count == 0)
		    {
			    throw new Exception("Could not find the method.");
		    }

		    for (int i = 0; i < list.Count; i++)
		    {
			    

				if (i == 6)
			    {
				    
			    }

			    var currentSemanticMethod = list[i];

			    if (!(currentSemanticMethod is BoundMethodDefinitionMask_I boundMethod))
			    {
				    throw new Exception($"The converted type {boundTypeWithMethods.FullName} has a non-bound method present and it cannot be used to get a method info.");
			    }

			    var method = boundMethod.UnderlyingMethod;

			    if (!VerifyReturnType(conversion, currentSemanticMethod.MethodReference, methodReference)) continue;

			    if (!VerifyGenericArguments(currentSemanticMethod.MethodReference, methodReference)) continue;

			    if (!VerifyParameters(conversion, currentSemanticMethod.MethodReference, methodReference)) continue;

			    return method;

				//var currentSemanticMethod = list[i];

				if (Cecil.Metadata.Members.Methods.AreSame(currentSemanticMethod.MethodReference, methodReference))
				{
					if (!(currentSemanticMethod is BoundMethodDefinitionMask_I boundMethod1))
					{
						throw new Exception($"The converted type {boundTypeWithMethods.FullName} has a non-bound method present and it cannot be used to get a method info.");
					}

					var method1 = boundMethod1.UnderlyingMethod;

					return method1;
				}

			}

		    for (int i = 0; i < list.Count; i++)
		    {


			    if (i == 6)
			    {

			    }

			    var currentSemanticMethod = list[i];


			    if (Cecil.Metadata.Members.Methods.AreSame(currentSemanticMethod.MethodReference, methodReference))
			    {
				    if (!(currentSemanticMethod is BoundMethodDefinitionMask_I boundMethod1))
				    {
					    throw new Exception($"The converted type {boundTypeWithMethods.FullName} has a non-bound method present and it cannot be used to get a method info.");
				    }

				    var method1 = boundMethod1.UnderlyingMethod;

				    return method1;
			    }

		    }

			throw new Exception("Could not find the method.");
	    }

	    

		private bool VerifyParameters(ILConversion conversion, MethodReference currentMethod, MethodReference targetMethod)
	    {
		    var currentParameters = currentMethod.Parameters;

		    var targetParameters = targetMethod.Parameters;

		    if (currentParameters.Count != targetParameters.Count) return false;

		    for (int i = 0; i < currentParameters.Count; i++)
		    {
			    var currentParameter = currentParameters[i];

			    var targetParameter = targetParameters[i];

			    var currentParameterType = currentParameter.ParameterType;

			    var targetParameterType = targetParameter.ParameterType;

			    targetParameterType = ResolveGenericParameterIfNeeded(targetMethod, targetParameterType);

			    if (!VerifyTypeMatch(conversion, currentParameterType, targetParameterType)) return false;

			    if (
					//The parameter attributes shall be attached to the parameters (§II.22.33) and hence are not part of a method signature. (p. 180 CLI Infrastructure)
					//currentParameter.IsIn != targetParameter.IsIn ||
					//currentParameter.IsOut != targetParameter.IsOut ||
					currentParameterType.IsByReference != targetParameterType.IsByReference)
			    {
				    return false;
			    }


		    }
		    return true;
	    }

	    private static TypeReference ResolveGenericParameterIfNeeded(MethodReference targetMethod, TypeReference targetParameterType)
	    {
		    if (targetParameterType.IsGenericParameter)
		    {
			    GenericParameter genericParameterType = (GenericParameter) targetParameterType;

			    if (targetParameterType.DeclaringType != null)
			    {
				    GenericInstanceType genericInstance = (GenericInstanceType) targetMethod.DeclaringType;

				    targetParameterType = genericInstance.GenericArguments[genericParameterType.Position];
			    }
			    //else
			    //{
				   // GenericInstanceMethod genericInstanceMethod = (GenericInstanceMethod) targetMethod;

				   // targetParameterType = genericInstanceMethod.GenericArguments[genericParameterType.Position];
			    //}
		    }
		    return targetParameterType;
	    }

	    private bool VerifyReturnType(ILConversion conversion, MethodReference currentMethod, MethodReference targetMethod)
	    {
		    var currentReturnType = currentMethod.ReturnType;

		    var targetReturnType = targetMethod.ReturnType;

		    targetReturnType = ResolveGenericParameterIfNeeded(targetMethod, targetReturnType);

		    return VerifyTypeMatch(conversion, currentReturnType, targetReturnType);		    
	    }

	    public bool VerifyGenericArguments(MethodReference currentMethod, MethodReference targetReference)
	    {
		    if (currentMethod is MethodDefinition currentMethodDefinition && targetReference is GenericInstanceMethod targetMethod)
		    {
			    return currentMethodDefinition.GenericParameters.Count == targetMethod.GenericArguments.Count;
		    }

		    return currentMethod.GenericParameters.Count == targetReference.GenericParameters.Count;

	    }

	    private bool VerifyTypeMatch(ILConversion conversion, TypeReference currentType1, TypeReference currentType2)
	    {
		    var test = Cecil.Types.AreSame(currentType1, currentType2);

		    return test;

			// LEAVE CODE FOR NOW - OLD WAY STILL MIGHT BE USED IN FUTURE.

			//if (currentType1.IsByReference != currentType2.IsByReference) return false;

		 //   if (currentType1.IsByReference && currentType2.IsByReference)
		 //   {
			//    return VerifyTypeMatch(conversion, currentType1.GetElementType(), currentType2.GetElementType());
		 //   }

		 //   var currentType1IsGenericParameter = currentType1.IsGenericParameter;

		 //   var currentType2IsGenericParameter = currentType2.IsGenericParameter;

		 //   var currentType1IsGenericInstance = currentType1.IsGenericInstance;

		 //   var currentType2IsGenericInstance = currentType2.IsGenericInstance;

		 //   if (currentType1IsGenericParameter || currentType2IsGenericParameter)
		 //   {
			//    if ((currentType1IsGenericParameter && !currentType2IsGenericParameter) ||
			//        (!currentType1IsGenericParameter && currentType2IsGenericParameter)) return false;

			//    var genericParameter1 = (GenericParameter) currentType1;

			//    var genericParameter2 = (GenericParameter)currentType2;

			//    if (genericParameter1.Position != genericParameter2.Position) return false;

			//	var genericParameter1HasDeclaringType = genericParameter1.DeclaringType != null;
			//    var genericParameter2HasDeclaringType = genericParameter2.DeclaringType != null;

			//    if (genericParameter1HasDeclaringType || genericParameter2HasDeclaringType)
			//    {
			//	    if ((genericParameter1HasDeclaringType && !genericParameter2HasDeclaringType) ||
			//	        (!genericParameter1HasDeclaringType && genericParameter2HasDeclaringType)) return false;

			//	    if (!VerifyTypeMatch(conversion, genericParameter1.DeclaringType, genericParameter2.DeclaringType)) return false;
			//    }
			//    else // has method
			//    {
			//	    var declaringMethod1 = genericParameter1.DeclaringMethod;
			//	    var declaringMethod2 = genericParameter2.DeclaringMethod;

			//	    if (declaringMethod1.Name != declaringMethod2.Name) return false;

			//	    if (!VerifyTypeMatch(conversion, declaringMethod1.DeclaringType, declaringMethod2.DeclaringType)) return false;
			//	}

			//    // If it is a generic parameter type, whether class or method, it can be ignored as it does not make the signature unique.
			//	return true;
		 //   }
		 //   if (currentType1IsGenericInstance || currentType2IsGenericInstance)
		 //   {
			//    if ((currentType1IsGenericInstance && !currentType2IsGenericInstance) ||
			//        (!currentType1IsGenericInstance && currentType2IsGenericInstance)) return false;

			//    var elementType1 = currentType1.GetElementType();

			//    var elementType2 = currentType2.GetElementType();

			//    var result = VerifyTypeMatch(conversion, elementType1, elementType2);

			//    if (!result) return false;

			//    var currentType1Arguments = ((GenericInstanceType)currentType1).GenericArguments;

			//    var currentType2Arguments = ((GenericInstanceType)currentType2).GenericArguments;

			//    if (currentType1Arguments.Count != currentType2Arguments.Count)
			//    {
			//	    throw new Exception("Missing a case.");
			//    }

			//    // Go through each generic argument.  
			//    for (int i = 0; i < currentType1Arguments.Count; i++)
			//    {
			//	    var currentType1Argument = currentType1Arguments[i];

			//	    var currentType2Argument = currentType2Arguments[i];

			//	    result = VerifyTypeMatch(conversion, currentType1Argument, currentType2Argument);

			//	    if (!result) return false;
			//    }

			//    return true;
			//}

		 //   var semanticType1 = Execution.Types.Ensuring.EnsureBound(conversion, currentType1);

		 //   var semanticType2 = Execution.Types.Ensuring.EnsureBound(conversion, currentType2);

		 //   return ReferenceEquals(semanticType1, semanticType2);
	    }

	   
	}
}
