using System;
using System.Text;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Rocks;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public class MethodApi<TContainer> : CecilApiNode<TContainer>, MethodApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public BuildingApi_I<TContainer> Building { get; set; }


		BuildingApiMask_I MethodApiMask_I.Building => Building;

		public EnsuringApi_I<TContainer> Ensuring { get; set; }
		

		EnsuringApiMask_I MethodApiMask_I.Ensuring => Ensuring;

		public GettingApi_I<TContainer> Getting { get; set; }


		GettingApiMask_I MethodApiMask_I.Getting => Getting;


		

		

		

		

		

		public MethodDefinition ResolveReferenceToNonSignatureDefinition(RuntimicSystemModel model, MethodReference methodReference)
		{
			var declaringType = methodReference.DeclaringType;

			var typeDefinition = Types.Getting.GetDefinition(model, declaringType);

			if (typeDefinition == null)
			{
				throw new Exception("Resolved declaring type definition is null");
			}

			var methods = typeDefinition.Methods;

			for (int i = 0; i < methods.Count; i++)
			{
				var methodDefinition = methods[i];

				if (AreSame(model, methodDefinition, methodReference, false)) return methodDefinition;
			}

			throw new System.Exception("Could not find method");

		}



		public bool AreSame(RuntimicSystemModel model, MethodReference methodDefinition, MethodReference methodReference, bool resolveTypeParametersIfPresentInMethodB)
		{
			if (methodDefinition.Name != methodReference.Name)
				return false;

			if (methodDefinition.HasGenericParameters != methodReference.HasGenericParameters)
				return false;

			if (methodDefinition.HasGenericParameters && methodDefinition.GenericParameters.Count != methodReference.GenericParameters.Count)
				return false;

			if (!Types.AreSame(methodDefinition.ReturnType, methodReference.ReturnType))
				return false;

			if (IsVarArg(methodDefinition) != IsVarArg(methodReference))
				return false;

			if (IsVarArg(methodDefinition) && IsVarArgCallTo(methodDefinition, methodReference))
				return true;

			if (methodDefinition.HasParameters != methodReference.HasParameters)
				return false;

			if (!methodDefinition.HasParameters && !methodReference.HasParameters)
				return true;

			MethodReference methodReferenceToResolve = resolveTypeParametersIfPresentInMethodB ? methodReference : null;

			if (!AreSame(model, methodDefinition.Parameters, methodReference.Parameters, methodReferenceToResolve))
				return false;

			return true;
		}

		

		public bool AreSame(RuntimicSystemModel model, Collection<ParameterDefinition> a, Collection<ParameterDefinition> b, MethodReference bMethod)
		{
			var count = a.Count;

			if (count != b.Count)
				return false;

			if (count == 0)
				return true;

			for (int i = 0; i < count; i++)
			{
				var aType = a[i].ParameterType;

				var bType = b[i].ParameterType;

				if (bMethod != null)
				{
					bType = ResolveTypeParameterIfPresent(model, bMethod, bType);
				}

				if (!Types.AreSame(aType, bType))
					return false;
			}
				

			return true;
		}

		public TypeReference ResolveTypeParameterIfPresent(RuntimicSystemModel model, MethodReference calledMethod, TypeReference typeToResolve)
		{
			if (!calledMethod.DeclaringType.IsGenericInstance) return typeToResolve;

			GenericInstanceType genericInstance = (GenericInstanceType)calledMethod.DeclaringType;

			return ResolveTypeParameterIfPresent(model, genericInstance.GenericArguments.ToArray(), typeToResolve);

		}

		/// <summary>
			/// Resolves a type parameter for when a generic instance method is being created.  
			/// This should not be used for resolving generic instance methods that are instructions as 
			/// generic instance method arguments are not resolved.
			/// </summary>
			/// <param name="model"></param>
			/// <param name="genericInstanceTypeArguments"></param>
			/// <param name="typeToResolve"></param>
			/// <returns></returns>
			public TypeReference ResolveTypeParameterIfPresent(RuntimicSystemModel model, TypeReference[] genericInstanceTypeArguments, TypeReference typeToResolve)
		{


			if (typeToResolve.IsByReference)
			{
				var inputByReferenceType = (ByReferenceType)typeToResolve;

				var inputByReferenceTypeElement = inputByReferenceType.ElementType;

				var result = ResolveTypeParameterIfPresent(model, genericInstanceTypeArguments, inputByReferenceTypeElement);

				return new ByReferenceType(result);
			}

			if (typeToResolve.IsArray)
			{
				var arrayType = (ArrayType)typeToResolve;

				var rank = arrayType.Rank;

				var arrayElementType = arrayType.ElementType;

				var arrayElementReferenceType = ResolveTypeParameterIfPresent(model, genericInstanceTypeArguments, arrayElementType);

				if (rank == 1)
				{
					return new ArrayType(arrayElementReferenceType);
				}
				else
				{
					return new ArrayType(arrayElementReferenceType, rank);
				}
			}

			if (typeToResolve.IsGenericInstance)
			{
				GenericInstanceType genericInstanceType = (GenericInstanceType)typeToResolve;

				var genericInstanceTypeDef = ResolveTypeParameterIfPresent(model, genericInstanceTypeArguments, genericInstanceType.ElementType);

				TypeReference[] arguments = new TypeReference[genericInstanceType.GenericArguments.Count];

				for (int i = 0; i < genericInstanceType.GenericArguments.Count; i++)
				{
					arguments[i] = ResolveTypeParameterIfPresent(model, genericInstanceTypeArguments,
						genericInstanceType.GenericArguments[i]);
				}

				return genericInstanceTypeDef.MakeGenericInstanceType(arguments);
			}

			if (!typeToResolve.IsGenericParameter)
			{
				return Infrastructure.Structural.Types.Ensure(model, typeToResolve).CecilTypeReference;
			}

			var genericParameter = (GenericParameter)typeToResolve;

			if (genericParameter.Type == GenericParameterType.Type)
			{
				// Becauase there is different generic instance type is created for each set of type arguments, generic parameters that are 
				// type arguments can be replaced.
				return genericInstanceTypeArguments[genericParameter.Position];
			}
			else
			{
				// This method is called when creating method references for all instructions that might encounter this method reference.
				// When this method is built, there is no way to know ahead of time what instructions might be calling it.  Thus, this needs to 
				// return just the method type parameter.
				return typeToResolve;
			}


		}

		//public TypeReference ResolveTypeParameterIfPresent(RuntimicSystemModel model, MethodReference calledMethod, TypeReference typeToResolve)
		//{
		//	if (typeToResolve.IsByReference)
		//	{
		//		var inputByReferenceType = (ByReferenceType)typeToResolve;

		//		var inputByReferenceTypeElement = inputByReferenceType.ElementType;

		//		var result = ResolveTypeParameterIfPresent(model, calledMethod, inputByReferenceTypeElement);

		//		return new ByReferenceType(result);
		//	}

		//	if (typeToResolve.IsArray)
		//	{
		//		var arrayType = (ArrayType)typeToResolve;

		//		var rank = arrayType.Rank;

		//		var arrayElementType = arrayType.ElementType;

		//		var arrayElementReferenceType = ResolveTypeParameterIfPresent(model, calledMethod, arrayElementType);

		//		if (rank == 1)
		//		{
		//			return new ArrayType(arrayElementReferenceType);
		//		}
		//		else
		//		{
		//			return new ArrayType(arrayElementReferenceType, rank);
		//		}
		//	}

		//	if (!typeToResolve.IsGenericParameter)
		//	{
		//		return Infrastructure.Structural.Types.Ensure(model, typeToResolve).CecilTypeReference;

		//	}

		//	var genericParameter = (GenericParameter)typeToResolve;

		//	if (genericParameter.Type == GenericParameterType.Type)
		//	{
		//		GenericInstanceType genericInstance = (GenericInstanceType)calledMethod.DeclaringType;

		//		if (genericInstance.GenericArguments.Count < genericParameter.Position)
		//		{
		//			throw new Exception($"Expected a generic parameter on the current type for position { genericParameter.Position}.");
		//		}

		//		return genericInstance.GenericArguments[genericParameter.Position];
		//	}

		//	// Method parameters would never be converted because you whould not know in advance what they were going to be.

		//	return typeToResolve;
		//}

		public string GetResolutionName(MethodReference methodReference)
		{
			var builder = new StringBuilder();
			
			builder.Append(GetTypeReference(methodReference.ReturnType));
			builder.Append(" ");
			builder.Append(GetTypeReference(methodReference.DeclaringType));
			builder.Append("::");
			builder.Append(methodReference.Name);
			
			builder.Append("(");

			if (methodReference.HasParameters)
			{
				var parameters = methodReference.Parameters;

				for (int i = 0; i < parameters.Count; i++)
				{
					var parameter = parameters[i];
					if (i > 0)
						builder.Append(",");

					if (parameter.ParameterType.IsSentinel)
						builder.Append("...,");

					builder.Append(GetTypeReference(parameter.ParameterType));
				}
			}

			builder.Append(")");
			
			return builder.ToString();
		}

		public string GetTypeReference(TypeReference typeReference)
		{
			if (typeReference.IsGenericParameter)
			{
				GenericParameter parameter = (GenericParameter) typeReference;

				if (parameter.Type == GenericParameterType.Type)
				{
					return "!!" + parameter.Position;
				}

				return "!!" + parameter.Name;
			}

			return Types.Naming.GetResolutionName(typeReference);
		}

		public bool IsVarArgCallTo(MethodReference method, MethodReference reference)
		{
			if (method.Parameters.Count >= reference.Parameters.Count)
				return false;

			if (GetSentinelPosition(reference) != method.Parameters.Count)
				return false;

			for (int i = 0; i < method.Parameters.Count; i++)
				if (!Types.AreSame(method.Parameters[i].ParameterType, reference.Parameters[i].ParameterType))
					return false;

			return true;
		}

		

		public static bool IsVarArg(IMethodSignature self)
		{
			return (self.CallingConvention & MethodCallingConvention.VarArg) != 0;
		}

		public static int GetSentinelPosition(IMethodSignature self)
		{
			if (!self.HasParameters)
				return -1;

			var parameters = self.Parameters;
			for (int i = 0; i < parameters.Count; i++)
				if (parameters[i].ParameterType.IsSentinel)
					return i;

			return -1;
		}

	}
}
