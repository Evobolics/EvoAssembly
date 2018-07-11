using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors.Building
{
	public class DynamicallyCreatedApi<TContainer> : BindingApiNode<TContainer>, DynamicallyCreatedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		//public void BuildMethods(InfrastructureModelMask_I model, BoundTypeDefinition_I input)
		//{
		//	// Done on purpose to find errors
		//	var typeDefinition = (TypeDefinition)input.SourceTypeReference;

		//	if (!typeDefinition.HasMethods) return;

		//	for (int i = 0; i < typeDefinition.Methods.Count; i++)
		//	{
		//		var method = typeDefinition.Methods[i];

		//		BuildMethod(model, input, method);
		//	}
		//}

		//public void BuildMethod(InfrastructureModelMask_I model, BoundTypeDefinition_I input, MethodDefinition method)
		//{
		//	//if (input.IsGeneric() && input is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType())
		//	//{
		//	//	return;
		//	//}

		//	//if (!(input is ConvertedTypeDefinitionWithMethods_I convertedTypeWithMethods))
		//	//{
		//	//	throw new Exception("Trying to add a method to a type that does not support methods.");
		//	//}

		//	//var methodEntry = new ConvertedNonGenericInstanceMethod
		//	//{
		//	//	MethodReference = method,
		//	//	DeclaringType = input,
		//	//	MethodAttributes = BuildMethodAttributes(method),
		//	//	Name = method.Name
		//	//};

		//	//if (!convertedTypeWithMethods.Methods.ByName.TryGetValue(methodEntry.Name, out List<SemanticMethodMask_I> methods))
		//	//{
		//	//	methods = new List<SemanticMethodMask_I>();

		//	//	convertedTypeWithMethods.Methods.ByName.Add(methodEntry.Name, methods);
		//	//}

		//	//methods.Add(methodEntry);

		//	//methodEntry.MethodBuilder = convertedTypeWithMethods.TypeBuilder.DefineMethod(method.Name, methodEntry.MethodAttributes);

		//	//// Needs method builder to create the generic parameters
		//	//AddGenericParameters(model, input, methodEntry);

		//	//Routines.Building.BuildRoutine(model, input, methodEntry);





		//	//var runtimeReturnType = methodEntry.ReturnType.UnderlyingType;

		//	//var systemParameterTypes = Parameters.GetSystemParameterTypes(model, methodEntry.Parameters.All);

		//	//methodEntry.MethodBuilder.SetSignature(runtimeReturnType, Type.EmptyTypes, Type.EmptyTypes, systemParameterTypes, null, null);

		//	//Routines.Building.CreateParameterBuilders(model, methodEntry);

		//	//SetImplementationFlagsIfPresent(method, methodEntry.MethodBuilder);
		//}

		////public void AddGenericParameters(InfrastructureModelMask_I model, ConvertedTypeDefinition_I input, ConvertedNonGenericInstanceMethod methodEntry)
		////{
		////	var methodDefinition = methodEntry.MethodReference;

		////	if (!methodDefinition.HasGenericParameters) return;

		////	List<string> genericParameterNamesList = new List<string>();

		////	foreach (var genericParamater in methodDefinition.GenericParameters)
		////	{
		////		var genericParamaterTypeDefintionEntry = new ConvertedGenericParameterTypeDefinition()
		////		{
		////			Name = genericParamater.Name,
		////			DeclaringTypeDefinitionEntry = input,
		////			Definition = genericParamater,
		////			Position = genericParamater.Position,
		////			TypeParameterKind = TypeParameterKind.Method
		////		};

		////		genericParameterNamesList.Add(genericParamaterTypeDefintionEntry.Name);

		////		Methods.TypeParameters.Add(model, methodEntry, genericParamaterTypeDefintionEntry);


		////	}

		////	var genericParameterNames = genericParameterNamesList.ToArray();

		////	GenericTypeParameterBuilder[] genericTypeParameterBuilders = methodEntry.MethodBuilder.DefineGenericParameters(genericParameterNames);

		////	methodEntry.TypeParameters.Builders = genericTypeParameterBuilders;

		////	foreach (var builder in genericTypeParameterBuilders)
		////	{
		////		var name = builder.Name;

		////		var genericTypeParameterEntry = Methods.TypeParameters.GetOrThrow(conversion, methodEntry, name);

		////		var definition = genericTypeParameterEntry.Definition;

		////		var attributes = GetGenericParameterAttributes(definition);

		////		builder.SetGenericParameterAttributes(attributes);

		////		genericTypeParameterEntry.Builder = builder;

		////		if (definition.HasConstraints)
		////		{
		////			foreach (var constraint in definition.Constraints)
		////			{
		////				throw new NotImplementedException("Generic Parameter constraints not implemented yet.");
		////			}
		////		}

		////		genericTypeParameterEntry.UnderlyingType = builder;
		////	}
		////}

		////private static System.Reflection.GenericParameterAttributes GetGenericParameterAttributes(GenericParameter definiton)
		////{
		////	System.Reflection.GenericParameterAttributes attributes = System.Reflection.GenericParameterAttributes.None;

		////	if (definiton.HasDefaultConstructorConstraint)
		////	{
		////		attributes |= System.Reflection.GenericParameterAttributes.DefaultConstructorConstraint;
		////	}

		////	if (definiton.HasReferenceTypeConstraint)
		////	{
		////		attributes |= System.Reflection.GenericParameterAttributes.ReferenceTypeConstraint;
		////	}

		////	if (definiton.IsCovariant)
		////	{
		////		attributes |= System.Reflection.GenericParameterAttributes.Covariant;
		////	}

		////	if (definiton.IsContravariant)
		////	{
		////		attributes |= System.Reflection.GenericParameterAttributes.Contravariant;
		////	}

		////	if (definiton.HasNotNullableValueTypeConstraint)
		////	{
		////		attributes |= System.Reflection.GenericParameterAttributes.NotNullableValueTypeConstraint;
		////	}
		////	return attributes;
		////}

		////public System.Reflection.MethodAttributes BuildMethodAttributes(MethodDefinition methodDefinition)
		////{
		////	var newAttributes = default(System.Reflection.MethodAttributes);

		////	var attributes = methodDefinition.Attributes;

		////	if ((attributes & Mono.Cecil.MethodAttributes.Public) == Mono.Cecil.MethodAttributes.Public)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.Public;
		////	}
		////	else if ((attributes & Mono.Cecil.MethodAttributes.Family) == Mono.Cecil.MethodAttributes.Family)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.Family;
		////	}
		////	else if ((attributes & Mono.Cecil.MethodAttributes.FamANDAssem) == Mono.Cecil.MethodAttributes.FamANDAssem)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.FamANDAssem;
		////	}
		////	else if ((attributes & Mono.Cecil.MethodAttributes.Private) == Mono.Cecil.MethodAttributes.Private)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.Private;
		////	}
		////	else
		////	{
		////		if ((attributes & Mono.Cecil.MethodAttributes.Assembly) == Mono.Cecil.MethodAttributes.Assembly)
		////		{
		////			newAttributes |= System.Reflection.MethodAttributes.Assembly;
		////		}

		////		if ((attributes & Mono.Cecil.MethodAttributes.FamORAssem) == Mono.Cecil.MethodAttributes.FamORAssem)
		////		{
		////			newAttributes |= System.Reflection.MethodAttributes.FamORAssem;
		////		}
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.Abstract) == Mono.Cecil.MethodAttributes.Abstract)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.Abstract;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.CheckAccessOnOverride) == Mono.Cecil.MethodAttributes.CheckAccessOnOverride)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.CheckAccessOnOverride;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.Final) == Mono.Cecil.MethodAttributes.Final)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.Final;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.HasSecurity) == Mono.Cecil.MethodAttributes.HasSecurity)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.HasSecurity;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.HideBySig) == Mono.Cecil.MethodAttributes.HideBySig)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.HideBySig;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.NewSlot) == Mono.Cecil.MethodAttributes.NewSlot)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.NewSlot;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.PInvokeImpl) == Mono.Cecil.MethodAttributes.PInvokeImpl)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.PinvokeImpl;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.RequireSecObject) == Mono.Cecil.MethodAttributes.RequireSecObject)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.RequireSecObject;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.ReuseSlot) == Mono.Cecil.MethodAttributes.ReuseSlot)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.ReuseSlot;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.RTSpecialName) == Mono.Cecil.MethodAttributes.RTSpecialName)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.RTSpecialName;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.SpecialName) == Mono.Cecil.MethodAttributes.SpecialName)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.SpecialName;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.Static) == Mono.Cecil.MethodAttributes.Static)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.Static;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.UnmanagedExport) == Mono.Cecil.MethodAttributes.UnmanagedExport)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.UnmanagedExport;
		////	}

		////	if ((attributes & Mono.Cecil.MethodAttributes.Virtual) == Mono.Cecil.MethodAttributes.Virtual)
		////	{
		////		newAttributes |= System.Reflection.MethodAttributes.Virtual;
		////	}

		////	return newAttributes;
		////}

		////public void SetImplementationFlagsIfPresent(MethodDefinition methodDefintion, MethodBuilder methodBuilder)
		////{
		////	System.Reflection.MethodImplAttributes methodImplFlags = default(System.Reflection.MethodImplAttributes);
		////	bool setFlags = false;

		////	if (methodDefintion.IsRuntime)
		////	{
		////		methodImplFlags |= System.Reflection.MethodImplAttributes.Runtime;

		////		setFlags = true;
		////	}

		////	if (methodDefintion.IsManaged)
		////	{
		////		methodImplFlags |= System.Reflection.MethodImplAttributes.Managed;

		////		setFlags = true;
		////	}

		////	if (setFlags)
		////	{
		////		//methodDefintion.IsManaged;
		////		methodBuilder.SetImplementationFlags(methodImplFlags);
		////	}
		////}
	}
}
