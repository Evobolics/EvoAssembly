using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public class DefinitionApi<TContainer> : ConversionApiNode<TContainer>, DefinitionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.  This method first gets the type definition associated with the 
		/// type reference.
		/// </summary>
		//public MethodDefinition GetMethodDefinition(ILConversion conversion, TypeReference typeReference, MethodInfo method, MethodInfo methodFromGenericTypeDefinition)
		//{
		//	// Get the type definition that corresponds to the type reference.  This will store all the methods that are available.
		//	var typeDefinition = Cecil.Metadata.Members.Types.Getting.GetDefinition(conversion.Model, typeReference);

		//	return GetMethodDefinition(conversion, typeReference, typeDefinition, method, methodFromGenericTypeDefinition);
		//}



		//public MethodDefinition GetMethodDefinition(MethodReferenceSearch search)
		//{
		//	var methodDefinitions = search.GenericTypeDefinition.Methods;

		//	var name = search.GenericInstanceMethodInfo.Name;

		//	List<MethodDefinition> canidatesBasedUponName = new List<MethodDefinition>();

		//	for (int i = 0; i < methodDefinitions.Count; i++)
		//	{
		//		var methodDefinition = methodDefinitions[i];

		//		search.CurrentMethodReference = methodDefinition;

		//		if (methodDefinition.Name != name) continue;

		//		if (!VerifyGenericArguments(search)) continue;

		//		if (!VerifyReturnType(search)) continue;

		//		if (!VerifyParameters(search)) continue;

		//		canidatesBasedUponName.Add(methodDefinition);
		//	}

		//	if (canidatesBasedUponName.Count == 0)
		//	{
		//		throw new Exception($"Could not find a method matching the method name {name}.");
		//	}

		//	if (canidatesBasedUponName.Count == 1)
		//	{
		//		return canidatesBasedUponName[0];
		//	}



		//	throw new Exception($"Found more than one method matching the method name {search.GenericInstanceMethodInfo.Name}.");
		//}

		

		//private bool VerifyReturnType(MethodReferenceSearch search)
		//{
		//	var currentReturnType = search.CurrentMethodReference.ReturnType;

		//	var targetReturnType = search.GenericInstanceMethodInfo.ReturnType;

		//	var targetReturnTypeDefinition = search?.GenericTypeDefinitionMethodInfo?.ReturnType;

		//	return VerifyTypeMatch(search, currentReturnType, targetReturnType, targetReturnTypeDefinition);
		//}

		//public bool VerifyTypeMatch(MethodReferenceSearch search, TypeReference currentType1, TypeReference currentType2)
		//{
		//	if (currentType1.IsByReference != currentType2.IsByReference) return false;

		//	var currentType1IsGenericParameter = currentType1.IsGenericParameter;

		//	var currentType2IsGenericParameter = currentType2.IsGenericParameter;

		//	var currentType1IsGenericInstance = currentType1.IsGenericInstance;

		//	var currentType2IsGenericInstance = currentType2.IsGenericInstance;

		//	if (currentType1IsGenericParameter || currentType2IsGenericParameter)
		//	{
		//		if ((currentType1IsGenericParameter && !currentType2IsGenericParameter) ||
		//		    (!currentType1IsGenericParameter && currentType2IsGenericParameter)) return false;

		//		var genericParameter1 = (GenericParameter)currentType1;

		//		var genericParameter2 = (GenericParameter)currentType2;

		//		if (genericParameter1.Position != genericParameter2.Position) return false;



		//		var genericParameter1HasDeclaringType = genericParameter1.DeclaringType != null;
		//		var genericParameter2HasDeclaringType = genericParameter2.DeclaringType != null;

		//		if (genericParameter1HasDeclaringType || genericParameter2HasDeclaringType)
		//		{
		//			if ((genericParameter1HasDeclaringType && !genericParameter2HasDeclaringType) ||
		//			    (!genericParameter1HasDeclaringType && genericParameter2HasDeclaringType)) return false;

		//			if (!VerifyTypeMatch(search, genericParameter1.DeclaringType, genericParameter2.DeclaringType)) return false;
		//		}
		//		else // has method
		//		{
		//			var declaringMethod1 = genericParameter1.DeclaringMethod;
		//			var declaringMethod2 = genericParameter2.DeclaringMethod;

		//			if (declaringMethod1.Name != declaringMethod2.Name) return false;

		//			if (!VerifyTypeMatch(search, declaringMethod1.DeclaringType, declaringMethod2.DeclaringType)) return false;
		//		}

		//		// If it is a generic parameter type, whether class or method, it can be ignored as it does not make the signature unique.
		//		return true;
		//	}
		//	if (currentType1IsGenericInstance || currentType2IsGenericInstance)
		//	{
		//		if ((currentType1IsGenericInstance && !currentType2IsGenericInstance) ||
		//		    (!currentType1IsGenericInstance && currentType2IsGenericInstance)) return false;

		//		var elementType1 = currentType1.GetElementType();

		//		var elementType2 = currentType2.GetElementType();

		//		var result = VerifyTypeMatch(search, elementType1, elementType2);

		//		if (!result) return false;

		//		var currentType1Arguments = ((GenericInstanceType)currentType1).GenericArguments;

		//		var currentType2Arguments = ((GenericInstanceType)currentType2).GenericArguments;

		//		if (currentType1Arguments.Count != currentType2Arguments.Count)
		//		{
		//			throw new Exception("Missing a case.");
		//		}

		//		// Go through each generic argument.  
		//		for (int i = 0; i < currentType1Arguments.Count; i++)
		//		{
		//			// If the generic argument position is a method parameter or a class parameter, ignore.
		//			//if (IsClassParameter(i))
		//			var currentType1Argument = currentType1Arguments[i];

		//			var currentType2Argument = currentType2Arguments[i];

		//			result = VerifyTypeMatch(search, currentType1Argument, currentType2Argument);

		//			if (!result) return false;
		//		}

		//		return true;
		//	}

		//	var semanticType1 = Types.Ensuring.EnsureBound(search.Conversion, currentType1);

		//	var semanticType2 = Types.Ensuring.EnsureBound(search.Conversion, currentType2);

		//	return ReferenceEquals(semanticType1, semanticType2);
		//}

		//public bool VerifyTypeMatch(MethodReferenceSearch search, TypeReference currentType1, Type currentType2, Type currentType2Def)
		//{
		//	if (currentType1.IsByReference != currentType2.IsByRef) return false;

		//	var currentType1IsGenericParameter = currentType1.IsGenericParameter;

		//	var currentType2DefIsGenericParameter = currentType2Def.IsGenericParameter;

		//	var currentType1IsGenericInstance = currentType1.IsGenericInstance;

		//	var currentType2IsGenericInstance = ((TypeInfo)currentType2).GenericTypeArguments.Length > 0;

		//	if (currentType1IsGenericParameter || currentType2DefIsGenericParameter)
		//	{
		//		if ((currentType1IsGenericParameter && !currentType2DefIsGenericParameter) ||
		//		    (!currentType1IsGenericParameter && currentType2DefIsGenericParameter)) return false;

		//		// If it is a generic parameter type, whether class or method, it can be ignored as it does not make the signature unique.
		//		return true;

		//		#region Not needed
		//		//var genericParameter = (GenericParameter)currentType1;
		//		//if (genericParameter.DeclaringType != null)
		//		//{
		//		//	// Generic Parameter is from a class.  Either it is from the class declaring this method or a parent class to a nested class declaring this method.
		//		//	// Either way, it does not need to be checked to see if the method is the correct one, as parameter types just have to be unique in number to a method.
		//		//	// ** The below code for this case can be removed, when done testing.

		//		//	var declaringType = genericParameter.DeclaringType;

		//		//	var currentMethodDeclaringType = matchInfo.CurrentMethodReference.DeclaringType;

		//		//	if (declaringType == currentMethodDeclaringType)
		//		//	{
		//		//		// All is good, the parameter type came from the class declaring the method
		//		//		return true;
		//		//	}
		//		//	else
		//		//	{
		//		//		// All is good, the parameter type came from a parent class to the nested class declaring this method.  It is not used to uniquely identify the method
		//		//		continue;
		//		//	}

		//		//}
		//		//else
		//		//{
		//		//	// Generic Parameter is from this method or another method, and either way is not unique to this method signature.
		//		//}
		//		#endregion
		//	}
		//	if (currentType1IsGenericInstance || currentType2IsGenericInstance)
		//	{
		//		if ((currentType1IsGenericInstance && !currentType2IsGenericInstance) ||
		//		    (!currentType1IsGenericInstance && currentType2IsGenericInstance)) return false;

		//		var elementType1 = currentType1.GetElementType();

		//		var elementType2 = currentType2.GetGenericTypeDefinition();

		//		var elementType2Def = currentType2Def.GetGenericTypeDefinition();

		//		var result = VerifyTypeMatch(search, elementType1, elementType2, elementType2Def);

		//		if (!result) return false;

		//		var currentType1Arguments = ((GenericInstanceType) currentType1).GenericArguments;

		//		var currentType2Arguments = ((TypeInfo)currentType2)?.GenericTypeArguments;

		//		Type[] currentType2DefArgsOrParms;

		//		// There is a slight difference in these two definition types.  The first one 
		//		// has just parameters, as the type just has a generic arguments passed to it.
		//		// The second one though has a string passed as one of the generic type arguments. 

		//		// Deal with Open Generic Types
		//		if (currentType2Def.IsGenericTypeDefinition) 
		//		{
		//			// Test GenericClassWithRecursiveMembers: 
		//			currentType2DefArgsOrParms = ((TypeInfo)currentType2Def)?.GenericTypeParameters;
		//			// The return type is: GenericClassWithRecursiveMembers<T>
		//		}
		//		// Deal with Closed Generic Types
		//		else
		//		{

		//			// Test GenericClassWithRecursiveMember: {Name = "GenericClassWithGenericFields`2" FullName = null}
		//			// The return type is: GenericClassWithGenericFields<string, T>
		//			currentType2DefArgsOrParms = ((TypeInfo)currentType2Def)?.GenericTypeArguments;
		//		}
				

		//		// Go through each generic argument.  
		//		for (int i = 0; i < currentType1Arguments.Count; i++)
		//		{
		//			// If the generic argument position is a method parameter or a class parameter, ignore.
		//			//if (IsClassParameter(i))
		//			var currentType1Argument = currentType1Arguments[i];

		//			var currentType2Argument = currentType2Arguments[i];

		//			if (i >= currentType2DefArgsOrParms.Length)
		//			{
		//				throw new Exception("Missing a case.");
		//			}

		//			var currentType2ArgumentDef = currentType2DefArgsOrParms[i];

		//			result = VerifyTypeMatch(search, currentType1Argument, currentType2Argument, currentType2ArgumentDef);					

		//			if (!result) return false;
		//		}

		//		return true;
		//	}
			
		//	var semanticType1 = Types.Ensuring.EnsureBound(search.Conversion, currentType1);

		//	var semanticType2 = Types.Ensuring.EnsureBound(search.Conversion, currentType2);

		//	return ReferenceEquals(semanticType1, semanticType2);
		//}

		//public bool VerifyGenericArguments(MethodReferenceSearch search)
		//{
			

		//	var genericArugments = search.GenericInstanceMethodInfo.GetGenericArguments();

		//	var cecilGenericParameters = search.CurrentMethodReference.GenericParameters;

		//	// ReSharper disable once ConditionIsAlwaysTrueOrFalse - NOT TRUE - it is reachable.
		//	if (genericArugments == null && (cecilGenericParameters == null || cecilGenericParameters.Count < 1)) return true;

		//	if (genericArugments.Length != cecilGenericParameters.Count) return false;

		//	return true;
		//}

		//public bool VerifyParameters(MethodReferenceSearch search)
		//{
		//	var parameters1 = search.CurrentMethodReference.Parameters;

		//	var parameters2 = search.GenericTypeDefinitionMethod.Parameters;

		//	if (parameters1.Count != parameters2.Count) return false;

		//	for (int i = 0; i < parameters1.Count; i++)
		//	{
		//		var parameter1 = parameters1[i];

		//		var parameter2 = parameters2[i];

		//		if (parameter1.IsIn != parameter2.IsIn ||
		//		    parameter1.IsOut != parameter2.IsOut) return false;

		//		var parameterType1 = parameter1.ParameterType;

		//		var parameterType2 = parameter2.ParameterType;

		//		if (!VerifyTypeMatch(search, parameterType1, parameterType2)) return false;
		//	}

		//	return true;

		//	//if (search.IsGenericTypeDefinitionConverted)
		//	//{
				
		//	//}
		//	//else
		//	//{
		//	//	var parameters1 = search.CurrentMethodReference.Parameters;

		//	//	var parameters2 = search.GenericInstanceMethodInfo.GetParameters();

		//	//	var parameters2Def = search.GenericTypeDefinitionMethodInfo.GetParameters();

		//	//	if (parameters1.Count != parameters2.Length) return false;

		//	//	for (int i = 0; i < parameters1.Count; i++)
		//	//	{
		//	//		var parameter1 = parameters1[i];

		//	//		var parameter2 = parameters2[i];

		//	//		var parameter2Def = parameters2Def[i];

		//	//		if (parameter1.IsIn != parameter2.IsIn ||
		//	//		    parameter1.IsOut != parameter2.IsOut) return false;

		//	//		var parameterType1 = parameter1.ParameterType;

		//	//		var parameterType2 = parameter2.ParameterType;

		//	//		var parameterType2Def = parameter2Def.ParameterType;

		//	//		if (!VerifyTypeMatch(search, parameterType1, parameterType2, parameterType2Def)) return false;
		//	//	}

		//	//	return true;
		//	//}
			
		//}

		//public BoundTypeDefinitionMask_I ResolveGenericParameterToArgumentType(MethodReferenceSearch search, GenericParameter parameter, MethodInfo methodInfo)
		//{
		//	if (parameter.DeclaringType != null)
		//	{
		//		var arguments = methodInfo.DeclaringType.GenericTypeArguments;

		//		var argument = arguments[parameter.Position];

		//		return Types.Ensuring.EnsureBound(search.Conversion, argument);
		//	}
		//	else
		//	{
		//		var arguments = methodInfo.GetGenericArguments();

		//		var argument = arguments[parameter.Position];

		//		return Types.Ensuring.EnsureBound(search.Conversion, argument);	
		//	}
		//}
	}

	//public class MatchInformation
	//{
	//	public ILConversion Conversion { get; set; }

	//	public MethodInfo MethodInfoOrginal { get; set; }

	//	public MethodInfo MethodInfoDefinition { get; set; }

	//	public TypeDefinition DeclaringTypeDefinition { get; set; }

	//	public TypeReference DeclaringTypeReference { get; set; }

	//	public MethodReference CurrentMethodReference { get; set; }

	//}
}
