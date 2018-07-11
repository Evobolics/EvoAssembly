using System.Reflection;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
	public class MethodApi<TContainer> : ConversionApiNode<TContainer>, MethodApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I MethodApiMask_I.Building => Building;

        public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I MethodApiMask_I.Getting => Getting;

        public TypeParameterApi_I<TContainer> TypeParameters { get; set; }

        TypeParameterApiMask_I MethodApiMask_I.TypeParameters => TypeParameters;


        public TypeScanningApi_I<TContainer> TypeScanning { get; set; }

        TypeScanningApiMask_I MethodApiMask_I.TypeScanning => TypeScanning;

	    

        



        public CallingConventions GetCallingConventions(MethodReference methodReference)
        {
            

            CallingConventions callingConventions = default(CallingConventions);

	        if (methodReference.HasThis)
	        {
				callingConventions |= CallingConventions.HasThis;
			}

            if ((methodReference.CallingConvention & MethodCallingConvention.C) == MethodCallingConvention.C)
            {

            }

            if ((methodReference.CallingConvention & MethodCallingConvention.Default) == MethodCallingConvention.Default)
            {
                callingConventions |= CallingConventions.Standard;
            }

            if ((methodReference.CallingConvention & MethodCallingConvention.FastCall) == MethodCallingConvention.FastCall)
            {

            }

            if ((methodReference.CallingConvention & MethodCallingConvention.Generic) == MethodCallingConvention.Generic)
            {

            }

            if ((methodReference.CallingConvention & MethodCallingConvention.StdCall) == MethodCallingConvention.StdCall)
            {
                callingConventions |= CallingConventions.Standard;
            }

            if ((methodReference.CallingConvention & MethodCallingConvention.ThisCall) == MethodCallingConvention.ThisCall)
            {
                callingConventions |= CallingConventions.HasThis;
            }

            if ((methodReference.CallingConvention & MethodCallingConvention.VarArg) == MethodCallingConvention.VarArg)
            {
                callingConventions |= CallingConventions.VarArgs;
            }

            return callingConventions;

        }

		//public MethodInfo FindMethodByNameAndSignature(ILConversion conversion, BoundTypeDefinitionMask_I declaringTypeEntry, MethodReference methodReference)
		//{

		//	if (declaringTypeEntry.IsConverted())
		//	{


		//		if (!declaringTypeEntry.IsArrayType())
		//		{

		//			if (declaringTypeEntry is ConvertedTypeDefinitionWithMethods_I convertedTypeWithMethods)
		//			{
		//				return GetMethodOrThrow(conversion, convertedTypeWithMethods, methodReference);
		//			}

		//			// Could be an array type - the set method presents itself as if its on this array type, but it is really in the base type.
		//			var baseType = declaringTypeEntry.BaseType;

		//			if (!baseType.IsBound())
		//			{
		//				throw new Exception("Expected a bound type");
		//			}

		//			return FindMethodByNameAndSignature(conversion, (BoundTypeDefinitionMask_I)baseType,
		//				methodReference);
		//		}

		//		//throw new Exception("Trying to find a method a method on a converted type that does not support methods.");

		//	}

		//	MethodInfo methodInfo1 = null;

		//	if (methodReference.ContainsGenericParameter)
		//	{


		//		methodInfo1 = FindGenericMethodBySignature(conversion, declaringTypeEntry, (GenericInstanceMethod)methodReference);
		//	}
		//	else
		//	{
		//		var parameterTypes = Parameters.GetSystemParameterTypes(conversion, methodReference);





		//		methodInfo1 = declaringTypeEntry.UnderlyingType.GetMethod(methodReference.Name, parameterTypes);
		//	}

		//	if (methodInfo1 == null)
		//	{
		//		throw new Exception("Coudl not find method");
		//	}

		//	return methodInfo1;
		//}

		//    public MethodInfo FindGenericMethodBySignature(ILConversion conversion, BoundTypeDefinitionMask_I declaringTypeEntry, GenericInstanceMethod methodSpecification)
		//    {
		//        if (!(declaringTypeEntry is BoundTypeDefinitionWithMethodsMask_I declaringTypeWithMethods))
		//        {
		//            throw new Exception("Expected a type that supported methods.");
		//        }

		//     MethodInfo methodInfo;

		//     if (FindMethodBySignature(conversion, methodSpecification, declaringTypeWithMethods, out methodInfo)) return methodInfo;



		//     //// If it is generic , then let it cascade down to look using the underlyign type.
		////if (!(converted.IsGeneric() && converted is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType()))
		////{
		////    throw new Exception("Not supported.");
		////}



		////var allMethods = GetAllMethods(declaringTypeEntry.UnderlyingType);

		////foreach (var method in allMethods)
		////{
		////    if (method.Name != methodSpecification.Name) continue;

		////    if (!VerifyGenericArguments(method, methodSpecification)) continue;                

		////    var map = CreateGenericArgumentMap(method);

		////    if (!VerifyParameters(conversion, method, methodSpecification, map)) continue;

		////    if (!VerifyReturnType(conversion, method, methodSpecification, map)) continue;

		////    return method;

		////}

		//throw new Exception("Not supported.");
		//    }

		//  private bool FindMethodBySignature(ILConversion conversion, GenericInstanceMethod methodSpecification,BoundTypeDefinitionWithMethodsMask_I declaringTypeWithMethods, out MethodInfo methodInfo)
		//  {
		//   foreach (var currentMethodEntryList in declaringTypeWithMethods.Methods.ByName.Values)
		//   {
		//    foreach (var currentMethodEntry in currentMethodEntryList)
		//    {
		//	    if (!(currentMethodEntry is ConvertedMethodMask_I convertedMethod))
		//	    {
		//		    throw new Exception("Not supported.");
		//	    }

		//	    var method = convertedMethod.UnderlyingMethod;

		//	    if (currentMethodEntry.Name != methodSpecification.Name) continue;

		//	    if (!VerifyGenericArguments(method, methodSpecification)) continue;

		//	    var map = CreateGenericArgumentMap(method);

		//	    if (!VerifyParameters(conversion, methodSpecification.Parameters, convertedMethod.MethodReference.Parameters, map)) continue;

		//	    if (!VerifyReturnType(conversion, method, methodSpecification, map)) continue;
		//	    {
		//		    methodInfo = method;
		//		    return true;
		//	    }
		//    }
		//   }
		//   methodInfo = null;

		//return false;
		//  }
		//private bool VerifyParameters(ILConversion conversion, Collection<ParameterDefinition> cecilParameters, Collection<ParameterDefinition> parameters, GenericArgumentEntryMap map)
	    //{
	    //    if (parameters.Count != cecilParameters.Count) return false;

	    //    int i = 0;

	    //    foreach (var currentParameter in cecilParameters)
	    //    {
	    //        var parameter = parameters[i];

	    //        var parameterType = parameter.ParameterType;

	    //        var cecilParameterType = currentParameter.ParameterType;

	    //        if (!VerifyTypeMatch(conversion, parameterType, cecilParameterType, map)) return false;

	    //        if (parameter.IsIn != currentParameter.IsIn ||
	    //            parameter.IsOut != currentParameter.IsOut ||
	    //            parameterType.IsByReference != cecilParameterType.IsByReference)
	    //        {
	    //            return false;
	    //        }

	    //        i++;

	    //    }

	    //    return true;
	    //}

	    //public bool VerifyParameters(ILConversion conversion, MethodInfo method, MethodReference methodSpecification, GenericArgumentEntryMap map)
	    //{
	    //    var parameters = method.GetParameters();

	    //    var cecilParameters = methodSpecification.Parameters;

	    //    if (parameters.Length != cecilParameters.Count) return false;

	    //    int i = 0;

	    //    foreach (var currentParameter in cecilParameters)
	    //    {
	    //        var parameter = parameters[i];

	    //        var parameterType = parameter.ParameterType;

	    //        var cecilParameterType = currentParameter.ParameterType;

	    //        if (!VerifyTypeMatch(conversion, parameterType, cecilParameterType, map)) return false;

	    //        if (parameter.IsIn != currentParameter.IsIn ||
	    //            parameter.IsOut != currentParameter.IsOut ||
	    //            parameterType.IsByRef != cecilParameterType.IsByReference)
	    //        {
	    //            return false;
	    //        }

	    //        i++;

	    //    }

	    //    return true;
	    //}



	    //private bool VerifyReturnType(ILConversion conversion, MethodInfo method, MethodReference methodSpecification, GenericArgumentEntryMap map)
	    //{
	    //    var runtimeReturnType = method.ReturnType;



	    //    var cecilReturnType = methodSpecification.ReturnType;

	    //    if (!VerifyTypeMatch(conversion, runtimeReturnType, cecilReturnType, map)) return false;

	    //    return true;
	    //}

	    //private bool VerifyTypeMatch(ILConversion conversion, Type runtimeReturnType, TypeReference cecilReturnType, GenericArgumentEntryMap map)
	    //{
	    //    if (runtimeReturnType.IsGenericParameter || (runtimeReturnType.IsByRef && runtimeReturnType.GetElementType().IsGenericParameter))
	    //    {
	    //        int genericParaterPosition = GetGenericParameterPosition(runtimeReturnType);

	    //        if ((cecilReturnType is TypeSpecification parameterTypeSpecification)
	    //            && parameterTypeSpecification.GenericParameters.Count > 0
	    //            && (parameterTypeSpecification.ElementType is GenericParameter cecilGenericParameter))
	    //        {
	    //            if (cecilGenericParameter.Position != genericParaterPosition) return false;
	    //        }
	    //        else if (cecilReturnType is GenericParameter cecilGenericParameter1)
	    //        {
	    //            if (cecilGenericParameter1.Position != genericParaterPosition) return false;
	    //        }
	    //        else
	    //        {
	    //            throw new NotSupportedException("Not supported yet.");
	    //        }
	    //    }
	    //    else
	    //    {
	    //        Type cecilType = null;

	    //        if (cecilReturnType is GenericParameter genericParameter)
	    //        {
	    //            if (genericParameter.Type == GenericParameterType.Method)
	    //            {
	    //                if (!map.Method.TryGetValue(genericParameter.Position, out GenericArgumentEntry genericArgumentEntry))
	    //                {
	    //                    return false;
	    //                }

	    //                cecilType = genericArgumentEntry.Type;
	    //            }
	    //            else
	    //            {
	    //                if (!map.Type.TryGetValue(genericParameter.Position, out GenericArgumentEntry genericArgumentEntry))
	    //                {
	    //                    return false;
	    //                }

	    //                cecilType = genericArgumentEntry.Type;
	    //            }

	    //            if (cecilType == null) throw new NotSupportedException("Not expected.");

	    //            if (cecilType.FullName != runtimeReturnType.FullName) return false;


	    //        }
	    //        else if (cecilReturnType is GenericInstanceType genericInstanceType)
	    //        {
	    //            var arguments = genericInstanceType.GenericArguments;

	    //            var types = new BoundTypeMask_I[arguments.Count];

	    //            int i = 0;

	    //            foreach (var argument in arguments)
	    //            {

	    //                if (argument is GenericParameter genericParameter1)
	    //                {
	    //                    if (genericParameter1.Type == GenericParameterType.Method)
	    //                    {
	    //                        if (!map.Method.TryGetValue(genericParameter1.Position, out GenericArgumentEntry genericArgumentEntry))
	    //                        {
	    //                            return false;
	    //                        }

	    //                        cecilType = genericArgumentEntry.Type;
	    //                    }
	    //                    else
	    //                    {
	    //                        if (!map.Type.TryGetValue(genericParameter1.Position, out GenericArgumentEntry genericArgumentEntry))
	    //                        {
	    //                            return false;
	    //                        }

	    //                        cecilType = genericArgumentEntry.Type;
	    //                    }

	    //                    var argumentTypeDefinitionEntry = Types.Ensuring.EnsureBound(conversion, argument);

	    //                    types[i++] = argumentTypeDefinitionEntry ?? throw new NotSupportedException("Not expected.");
	    //                }
	    //            }

	    //            throw new System.NotImplementedException("");
	    //            //var type = Models.Types.ResolveToType(conversion.Model, cecilReturnType, types);

	    //            //if (runtimeReturnType != type) return false;
	    //        }
	    //        else
	    //        {
	    //            var type1 = Types.Ensuring.EnsureBound(conversion, cecilReturnType);

	    //         var type2 = Types.Ensuring.EnsureBound(conversion, runtimeReturnType);

	    //            if (type1 != type2) return false;
	    //        }


	    //    }

	    //    return true;
	    //}

	    //private int GetGenericParameterPosition(System.Type parameterType)
	    //{
	    //    if (parameterType.HasElementType)
	    //    {
	    //        System.Type elementType = parameterType.GetElementType();

	    //        return elementType.GenericParameterPosition;
	    //    }
	    //    else
	    //    {
	    //        return parameterType.GenericParameterPosition;
	    //    }
	    //}

	    //public bool VerifyGenericArguments(MethodInfo method, GenericInstanceMethod methodSpecification)
	    //{
	    //    var genericArugments = method.GetGenericArguments();

	    //    var cecilGenericArguments = methodSpecification.GenericArguments;

	    //    if (genericArugments.Length != cecilGenericArguments.Count) return false;

	    //    return true;

	    //    //Dictionary<int, GenericArgumentEntry> genericTypeMapping = new Dictionary<int, GenericArgumentEntry>();

	    //    //int i = 0;

	    //    //foreach(var genericArgument in genericArugments)
	    //    //{

	    //    //    GenericArgumentEntry entry = new GenericArgumentEntry()
	    //    //    {
	    //    //        Name = genericArgument.Name,
	    //    //        Position = i++,
	    //    //        Type = genericArgument
	    //    //    };

	    //    //    genericTypeMapping.Add(entry.Position, entry);
	    //    //}

	    //    //return genericTypeMapping;
	    //}



	    //public GenericArgumentEntryMap CreateGenericArgumentMap(MethodInfo method)
	    //{
	    //    GenericArgumentEntryMap map = new GenericArgumentEntryMap();

	    //    if (method.Name == "Add")
	    //    {

	    //    }

	    //    if (method.IsGenericMethod)
	    //    {
	    //        var arguments = method.GetGenericArguments();

	    //        int i = 0;

	    //        foreach (var genericArgument in arguments)
	    //        {

	    //            GenericArgumentEntry entry = new GenericArgumentEntry()
	    //            {
	    //                Name = genericArgument.Name,
	    //                Position = i++,
	    //                Type = genericArgument
	    //            };

	    //            map.Method.Add(entry.Position, entry);
	    //        }
	    //    }

	    //    if (method.DeclaringType != null)
	    //    {

	    //        if (method.DeclaringType.IsGenericType)
	    //        {
	    //            int i = 0;

	    //            foreach (var genericArgument in method.DeclaringType.GenericTypeArguments)
	    //            {

	    //                GenericArgumentEntry entry = new GenericArgumentEntry()
	    //                {
	    //                    Name = genericArgument.Name,
	    //                    Position = i++,
	    //                    Type = genericArgument
	    //                };

	    //                map.Type.Add(entry.Position, entry);
	    //            }
	    //        }
	    //    }

	    //    return map;
	    //}

	    //public MethodInfo[] GetAllMethods(System.Type type)
	    //{
	    //    return type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
	    //}

	}
}
