using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Rocks;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building
{
	public class MethodDefinitionApi<TContainer> : CecilApiNode<TContainer>, MethodDefinitionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public MethodDefinition MakeGenericInstanceTypeMethodReference(RuntimicSystemModel model, GenericInstanceType declaringType, MethodDefinition methodDefinition)
		{
			if (declaringType == null) throw new Exception("Expected a declaring type.");

			var typeArgumentReferences = declaringType.GenericArguments.ToArray();

			if (typeArgumentReferences == null || typeArgumentReferences.Length < 1) return methodDefinition;

			var returnType = Infrastructure.Structural.Cecil.Methods.ResolveTypeParameterIfPresent(model, typeArgumentReferences, methodDefinition.ReturnType);

			var resolvedMethodDefinition = new MethodDefinition(methodDefinition.Name, methodDefinition.Attributes, returnType)
			{
				MetadataToken = methodDefinition.MetadataToken
			};
			//resolvedMethodDefinition.DeclaringType = methodDefinition.DeclaringType;

			//resolvedMethodDefinition.MetadataToken = methodDefinition.MetadataToken;

			// Add any method, not type, generic parameters
			AddGenericParameters(model, methodDefinition, resolvedMethodDefinition);

			

			

			for (int i = 0; i < methodDefinition.Parameters.Count; i++)
			{
				var inputParameter = methodDefinition.Parameters[i];

				var inputParameterType = inputParameter.ParameterType;

				var outputParameterType = Infrastructure.Structural.Cecil.Methods.ResolveTypeParameterIfPresent(model, typeArgumentReferences, inputParameterType);

				var outputParameter = Parameters.Create(inputParameter, outputParameterType);

				resolvedMethodDefinition.Parameters.Add(outputParameter);
			}

			

			return resolvedMethodDefinition;
		}

		public MethodDefinition MakeGenericInstanceTypeMethodReference(RuntimicSystemModel model, 
			MethodDefinition methodDefinition, Type memberDeclaringType, Type[] typeArguments)
		{
			if (memberDeclaringType == null) throw new Exception("Expected a declaring type.");

			

			TypeReference[] typeArgumentReferences = ResolveGenericArguments(model, typeArguments);

			var returnType = Infrastructure.Structural.Cecil.Methods.ResolveTypeParameterIfPresent(model, typeArgumentReferences, methodDefinition.ReturnType);

			var resolvedMethodDefinition = new MethodDefinition(methodDefinition.Name, methodDefinition.Attributes, returnType);

			AddGenericParameters(model, methodDefinition, resolvedMethodDefinition);

			int orginalCount = methodDefinition.Parameters.Count;

			if (resolvedMethodDefinition.HasParameters)
			{
				throw new Exception("Has parameters");
			}

			for (int i = 0; i < methodDefinition.Parameters.Count; i++)
			{
				var inputParameter = methodDefinition.Parameters[i];

				var inputParameterType = inputParameter.ParameterType;

				var outputParameterType = Infrastructure.Structural.Cecil.Methods.ResolveTypeParameterIfPresent(model, typeArgumentReferences, inputParameterType);

				var outputParameter = Parameters.Create(inputParameter, outputParameterType);

				

				resolvedMethodDefinition.Parameters.Add(outputParameter);
			}

			if (methodDefinition.Parameters.Count != orginalCount)
			{
				throw new Exception("Nope!");
			}

			return resolvedMethodDefinition;
		}

		private TypeReference[] ResolveGenericArguments(RuntimicSystemModel model, Type[] typeArguments)
		{
			TypeReference[] references = new TypeReference[typeArguments.Length];

			for (int i = 0; i < typeArguments.Length; i++)
			{
				references[i] = ResolveClassTypeArgument(model, typeArguments[i]);
			}

			return references;
		}

		public TypeReference ResolveClassTypeArgument(RuntimicSystemModel model, Type typeToResolve)
		{
			if (typeToResolve.IsByRef)
			{
				var inputByReferenceType = typeToResolve.GetElementType();

				var result = ResolveClassTypeArgument(model, inputByReferenceType);

				return new ByReferenceType(result);
			}

			if (typeToResolve.IsArray)
			{
				var arrayType = typeToResolve;

				var rank = arrayType.GetArrayRank();

				var arrayElementType = arrayType.GetElementType();

				var arrayElementReferenceType = ResolveClassTypeArgument(model, arrayElementType);

				if (rank == 1)
				{
					return new ArrayType(arrayElementReferenceType);
				}
				else
				{
					return new ArrayType(arrayElementReferenceType, rank);
				}
			}

			if (typeToResolve.IsGenericParameter)
			{
				if (typeToResolve.DeclaringMethod != null)
				{
					throw new Exception("Not handled");
				}

				var declaringType = typeToResolve.DeclaringType;

				var node = Infrastructure.Structural.Types.Ensure(model, declaringType);

				var declaringTypeReference = node.CecilTypeReference;

				var genericParameterTypeReference = declaringTypeReference.GenericParameters[typeToResolve.GenericParameterPosition];

				return genericParameterTypeReference;
			}

			var semanticType = Execution.Types.Ensuring.EnsureBound(model, typeToResolve);

			//return Types.Getting.GetInternalTypeReference(model, typeToResolve);

			return semanticType.SourceTypeReference;
		}

		


		private void AddGenericParameters(RuntimicSystemModel model, MethodDefinition input, MethodDefinition output)
		{
			for (int i = 0; i < input.GenericParameters.Count; i++)
			{
				output.GenericParameters.Add(input.GenericParameters[i]);
			}
		}
	}
}
