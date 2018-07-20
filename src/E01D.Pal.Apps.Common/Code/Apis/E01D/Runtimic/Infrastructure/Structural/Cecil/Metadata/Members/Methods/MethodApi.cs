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

				if (AreSame(model, methodDefinition, methodReference, false)) return methodDefinition;
			}

			throw new System.Exception("Could not find method");

		}



		public bool AreSame(StructuralRuntimicModelMask_I model, MethodReference methodDefinition, MethodReference methodReference, bool resolveTypeParametersIfPresentInMethodB)
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

		

		public bool AreSame(StructuralRuntimicModelMask_I model, Collection<ParameterDefinition> a, Collection<ParameterDefinition> b, MethodReference bMethod)
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

		public TypeReference ResolveTypeParameterIfPresent(StructuralRuntimicModelMask_I model, MethodReference calledMethod, TypeReference typeToResolve)
		{
			if (typeToResolve.IsByReference)
			{
				var inputByReferenceType = (ByReferenceType)typeToResolve;

				var inputByReferenceTypeElement = inputByReferenceType.ElementType;

				var result = ResolveTypeParameterIfPresent(model, calledMethod, inputByReferenceTypeElement);

				return new ByReferenceType(result);
			}

			if (typeToResolve.IsArray)
			{
				var arrayType = (ArrayType)typeToResolve;

				var rank = arrayType.Rank;

				var arrayElementType = arrayType.ElementType;

				var arrayElementReferenceType = ResolveTypeParameterIfPresent(model, calledMethod, arrayElementType);

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

			var genericParameter = (GenericParameter)typeToResolve;

			if (genericParameter.Type == GenericParameterType.Type)
			{
				GenericInstanceType genericInstance = (GenericInstanceType)calledMethod.DeclaringType;

				if (genericInstance.GenericArguments.Count < genericParameter.Position)
				{
					throw new Exception($"Expected a generic parameter on the current type for position { genericParameter.Position}.");
				}

				return genericInstance.GenericArguments[genericParameter.Position];
			}

			// Method parameters would never be converted because you whould not know in advance what they were going to be.

			return typeToResolve;
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
