using System;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting.FromMethodReference
{
	public class FromMethodReferenceApi<TContainer> : ConversionApiNode<TContainer>, FromMethodReferenceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public MethodInfo Get(ILConversion conversion, MethodReference methodReference, MethodInfo[] methods)
		{
			

			for (int i = 0; i < methods.Length; i++)
			{
				var method = methods[i];

				if (AreSameMethod(conversion, method, methodReference)) return method;
			}

			throw new Exception($"Could not find a method matching the method name {methodReference.Name}.");
		}

		private bool AreSameMethod(ILConversion conversion, MethodInfo method, MethodReference methodDefinition)
		{


			if (methodDefinition.Name != method.Name) return false;

			if (!VerifyGenericArguments(conversion, methodDefinition, method)) return false;

			// Do need - C# operators and CIL can overload methods with jsut return type.
			// https://blogs.msdn.microsoft.com/abhinaba/2005/10/07/c-cil-supports-overloading-by-return-type/
			if (!VerifyReturnType(conversion, methodDefinition, method)) return false;

			if (!VerifyParameters(conversion, methodDefinition, method)) return false;

			return true;
		}

		public bool VerifyGenericArguments(ILConversion conversion, MethodReference currentMethod, MethodInfo method)
		{
			var genericArugments = method.GetGenericArguments();

			var cecilGenericParameters = currentMethod.GenericParameters;

			if (genericArugments.Length != cecilGenericParameters.Count) return false;

			return true;
		}

		private bool VerifyReturnType(ILConversion conversion, MethodReference currentMethod, MethodInfo targetMethod)
		{
			var currentReturnType = currentMethod.ReturnType;

			var targetReturnType = targetMethod.ReturnType;

			return VerifyTypeMatch(conversion, currentReturnType, targetReturnType, targetMethod);


		}

		public bool VerifyTypeMatch(ILConversion conversion, TypeReference currentTypeReference, Type currentType, MethodInfo method)
		{
			if (currentType.MetadataToken == currentTypeReference.MetadataToken.ToInt32()) return true;

			// If one is a generic parameter and one is not, then return false;
			if (currentTypeReference.IsGenericParameter != currentType.IsGenericParameter)
			{
				return false;
			}

			// If they are just generic parameters, check the name only.
			if (currentTypeReference.IsGenericParameter && currentType.IsGenericParameter)
			{
				return currentTypeReference.Name == currentType.Name;
			}

			BoundTypeDefinitionMask_I type1;

			if (currentTypeReference.IsArray)
			{
				return VerifyTypeMatch_Array(conversion, (ArrayType)currentTypeReference, currentType, method);
			}
			if (currentTypeReference.IsGenericInstance)
			{
				return VerifyTypeMatch_GenericInstance(conversion, (GenericInstanceType)currentTypeReference, currentType, method);

			}

			if (currentTypeReference.IsGenericParameter)
			{
				if (method.GetGenericArguments().Length > 0)
				{
					throw new System.NotImplementedException();
					//type1 = ResolveGenericParameterToArgumentType(model, (GenericParameter) currentTypeReference, method);
				}
				else
				{
					throw new System.NotImplementedException();
					//type1 = ResolveGenericParameterToParameterType(model, (GenericParameter)currentTypeReference, method);
				}
			}
			else
			{
				type1 = Execution.Types.Ensuring.EnsureBound(conversion.Model, currentTypeReference);
			}

			var type2 = Execution.Types.Ensuring.EnsureBound(conversion.Model, currentType);

			return ReferenceEquals(type1, type2);
		}

		private bool VerifyTypeMatch_Array(ILConversion conversion, ArrayType currentTypeReference, Type currentType, MethodInfo method)
		{
			var elementTypeReference = currentTypeReference.ElementType;

			if (!currentType.HasElementType) return false;

			var elementType = currentType.GetElementType();

			if (!VerifyTypeMatch(conversion, elementTypeReference, elementType, method)) return false;

			if (!currentTypeReference.IsVector)
			{
				if (currentTypeReference.Rank != currentType.GetArrayRank()) return false;
			}

			return true;
		}

		private bool VerifyTypeMatch_GenericInstance(ILConversion conversion, GenericInstanceType currentTypeReference, Type currentType, MethodInfo method)
		{
			if (!VerifyTypeMatch(conversion, currentTypeReference.ElementType, currentType.GetGenericTypeDefinition(), method)) return false;

			var currentTypeReferenceArguments = currentTypeReference.GenericArguments;

			var typeArguments = ((TypeInfo)currentType).GenericTypeArguments;

			if (currentTypeReferenceArguments.Count != typeArguments.Length) return false;

			for (int i = 0; i < typeArguments.Length; i++)
			{
				var typeArugument = typeArguments[i];

				var typeArgumentReference = (GenericParameter)currentTypeReferenceArguments[i];

				if (typeArugument.MetadataToken == typeArgumentReference.MetadataToken.ToInt32()) continue;

				if (typeArugument.Name != typeArgumentReference.Name) return false;

				if (typeArugument.GenericParameterPosition != typeArgumentReference.Position) return false;

				var declaringMethod = typeArugument.DeclaringMethod;

				var declaringMethodReference = typeArgumentReference.DeclaringMethod;

				if (declaringMethod == null || declaringMethodReference == null)
				{
					// Needs to be placed wihtin the if statement, as generic type parameter that has a declaring method
					// also has a declaring type if it is a system type.  But this is not the case for cecil types.
					if ((typeArugument.DeclaringType == null && typeArgumentReference.DeclaringType != null)
						|| (typeArugument.DeclaringType != null && typeArgumentReference.DeclaringType == null)) return false;

					if (!VerifyTypeMatch(conversion, typeArgumentReference.DeclaringType, typeArugument.DeclaringType, method)) return false;
				}
				else
				{
					if (declaringMethod.Name != declaringMethodReference.Name) return false;

					if (declaringMethod.MetadataToken != declaringMethodReference.MetadataToken.ToInt32()) return false;


				}
			}

			return true;

			
		}

		public bool VerifyParameters(ILConversion conversion, MethodReference currentMethod, MethodInfo method)
		{
			var parameters = method.GetParameters();

			var cecilParameters = currentMethod.Parameters;

			if (parameters.Length != cecilParameters.Count) return false;

			int i = 0;

			foreach (var currentParameter in cecilParameters)
			{
				var parameter = parameters[i];

				var parameterType = parameter.ParameterType;

				var cecilParameterType = currentParameter.ParameterType;

				if (!VerifyTypeMatch(conversion, cecilParameterType, parameterType, method)) return false;

				if (
					//parameter.IsIn != currentParameter.IsIn ||
					//parameter.IsOut != currentParameter.IsOut ||
					parameterType.IsByRef != cecilParameterType.IsByReference)
				{
					return false;
				}

				i++;

			}

			return true;
		}
	}
}

