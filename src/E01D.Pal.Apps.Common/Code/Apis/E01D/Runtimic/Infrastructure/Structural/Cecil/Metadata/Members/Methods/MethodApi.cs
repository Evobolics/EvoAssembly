using System;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

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


		public bool ContainsMethodGenericParameters(MethodReference methodReference)
		{
			if (methodReference.GenericParameters.Count < 1) return false;

			for (int i = 0; i < methodReference.GenericParameters.Count; i++)
			{
				var genericParameter = methodReference.GenericParameters[i];

				if (genericParameter.DeclaringMethod != null) return true;
			}

			return false;
		}

		public bool ContainsClassGenericParameters(MethodReference methodReference)
		{
			throw new Exception("Wrong");
			//if (methodReference.GenericParameters.Count < 1) return false;

			//for (int i = 0; i < methodReference.GenericParameters.Count; i++)
			//{
			//	var genericParameter = methodReference.GenericParameters[i];

			//	if (genericParameter.DeclaringType != null) return true;
			//}

			//return false;
		}

		/// <summary>
		/// Used ot transform a reference from a 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="methodReference"></param>
		/// <returns></returns>
		public MethodReference ResolveSignatureReferenceToFullReference(StructuralRuntimicModelMask_I model, TypeReference callingMethodType, MethodDefinition callingMethodDefinition,
			MethodReference signatureMethodReference)
		{
			if (callingMethodDefinition.FullName == "System.Collections.Generic.List`1<TOutput> System.Collections.Generic.List`1::ConvertAll(System.Converter`2<T,TOutput>)")
			{
				
			}

			if (!signatureMethodReference.IsGenericInstance)
			{
				var result = ResolveReferenceToNonSignatureDefinition(model, signatureMethodReference);

				return result;
			}

			GenericInstanceMethod genericInstanceMethod = (GenericInstanceMethod)signatureMethodReference;

			var genericMethodDefinition = genericInstanceMethod.ElementMethod;

			var calledMethodDefinition = ResolveReferenceToNonSignatureDefinition(model, genericMethodDefinition);

			if (ReferenceEquals(calledMethodDefinition, genericMethodDefinition)) return signatureMethodReference;


			var genericArguments = genericInstanceMethod.GenericArguments;

			var resolvedMethodReference = new GenericInstanceMethod(calledMethodDefinition)
			{
				ReturnType = ResolveTypeParameterIfPresent(model, callingMethodType, callingMethodDefinition, calledMethodDefinition, genericInstanceMethod.ReturnType),
			};

			AddGenericArguments(model, callingMethodType, callingMethodDefinition, calledMethodDefinition, resolvedMethodReference, genericArguments);

			int orginalCount = genericInstanceMethod.Parameters.Count;

			for (int i = 0; i < genericInstanceMethod.Parameters.Count; i++)
			{
				var inputParameter = genericInstanceMethod.Parameters[i];

				var inputParameterType = inputParameter.ParameterType;

				var outputParameterType = ResolveTypeParameterIfPresent(model, callingMethodType, callingMethodDefinition, calledMethodDefinition, inputParameterType);

				var outputParameter = Parameters.Create(inputParameter, outputParameterType);

				resolvedMethodReference.Parameters.Add(outputParameter);
			}

			if (orginalCount != genericInstanceMethod.Parameters.Count)
			{
				throw new Exception("Ddi not work");
			}

			return resolvedMethodReference;
		}

		private void AddGenericArguments(StructuralRuntimicModelMask_I model, TypeReference currentType, MethodDefinition callingMethod, MethodDefinition calledMethod, GenericInstanceMethod resolvedMethodReference, Collection<TypeReference> typeArgumentReferences)
		{
			for (int i = 0; i < typeArgumentReferences.Count; i++)
			{
				var currentArgument = typeArgumentReferences[i];

				var resolved = ResolveTypeParameterIfPresent(model, currentType, callingMethod, calledMethod, currentArgument);

				resolvedMethodReference.GenericArguments.Add(resolved);
			}
		}

		private TypeReference ResolveTypeParameterIfPresent(StructuralRuntimicModelMask_I model, TypeReference currentType, 
			MethodDefinition callingMethod, MethodDefinition calledMethod, TypeReference typeToResolve)
		{
			if (typeToResolve.IsByReference)
			{
				var inputByReferenceType = (ByReferenceType)typeToResolve;

				var inputByReferenceTypeElement = inputByReferenceType.ElementType;

				var result = ResolveTypeParameterIfPresent(model, currentType, callingMethod, calledMethod, inputByReferenceTypeElement);

				return new ByReferenceType(result);
			}

			if (typeToResolve.IsArray)
			{
				var arrayType = (ArrayType)typeToResolve;

				var rank = arrayType.Rank;

				var arrayElementType = arrayType.ElementType;

				var arrayElementReferenceType = ResolveTypeParameterIfPresent(model, currentType, callingMethod, calledMethod, arrayElementType);

				if (rank == 1)
				{
					return new ArrayType(arrayElementReferenceType);
				}
				else
				{
					return new ArrayType(arrayElementReferenceType, rank);
				}
			}

			if (!typeToResolve.IsGenericParameter)
			{
				return Types.Getting.GetInternalTypeReference(model, typeToResolve);
			}

			var genericParameter = (GenericParameter) typeToResolve;

			if (genericParameter.Type == GenericParameterType.Type)
			{
				if (currentType.GenericParameters.Count < genericParameter.Position)
				{
					throw new Exception($"Expected a generic parameter on the current type for position { genericParameter.Position}.");
				}

				return currentType.GenericParameters[genericParameter.Position];
			}

			var genericParameterDeclaringMethod = genericParameter.DeclaringMethod;

			MethodReference methodReferenceContainingParameters;

			if (AreSame(callingMethod, genericParameterDeclaringMethod))
			{
				methodReferenceContainingParameters = callingMethod;
			}
			else if (AreSame(calledMethod, genericParameterDeclaringMethod))
			{
				methodReferenceContainingParameters = calledMethod;
			}
			else
			{
				throw new Exception("Could not match method");
			}

			if (methodReferenceContainingParameters.GenericParameters.Count < genericParameter.Position)
			{
				throw new Exception($"Expected a generic parameter on the current method for position { genericParameter.Position}.");
			}

			return methodReferenceContainingParameters.GenericParameters[genericParameter.Position];
		}

		public MethodDefinition ResolveReferenceToNonSignatureDefinition(StructuralRuntimicModelMask_I model, MethodReference methodReference)
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

				if (AreSame(methodDefinition, methodReference)) return methodDefinition;
			}

			throw new System.Exception("Could not find method");

		}

		public bool AreSame(MethodReference methodDefinition, MethodReference methodReference)
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

			if (!AreSame(methodDefinition.Parameters, methodReference.Parameters))
				return false;

			return true;
		}

		public bool AreSame(Collection<ParameterDefinition> a, Collection<ParameterDefinition> b)
		{
			var count = a.Count;

			if (count != b.Count)
				return false;

			if (count == 0)
				return true;

			for (int i = 0; i < count; i++)
				if (!Types.AreSame(a[i].ParameterType, b[i].ParameterType))
					return false;

			return true;
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
