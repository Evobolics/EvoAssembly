using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public class GenericInstanceTypeApi<TContainer> : ExecutionApiNode<TContainer>, GenericInstanceTypeApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public ExecutionTypeNode_I Ensure(ExecutionEnsureContext context)
		{
			if (!context.IsConverted.HasValue) throw new Exception("Expected conversion to be figured out.");

			// It would be nice if all generic instance types could be traced back signatures, but the signature 
			// of a generic instance is not always just stored in a type specification table.  Sometimes it is 
			// part of a method signature.  Thus, since it is basically a series of type definitions / references
			// that make a generic instance, the blueprint and the arguments have to be used to look up the 
			// particular instance that is required.

			var typeReference = (GenericInstanceType)context.TypeReference;

			// If not first, then a dependency is created by method calls needing the generic instance
			var blueprintNode = Execution.Types.Ensuring.Ensure(context, typeReference.ElementType, cloneContext: true);

			var blueprint = (BoundGenericTypeDefinitionMask_I)blueprintNode.Type;

			var typeArguments = Bound.Metadata.Members.TypeArguments.Building.Build(context, typeReference, out Type[] typeArgumentTypes);

			if (CheckForBranch(blueprintNode, typeArguments, out ExecutionGenericInstanceTypeNode ensure)) return ensure;

			var structuralInputTypeNode = context.StructuralInputTypeNode;

			var conversionTypeNode = new ExecutionGenericInstanceTypeNode()
			{
				
				ByReferenceType = null,
				Id = 0,
				InputStructuralNode = structuralInputTypeNode,
				IsDerived = true,
				
				PointerType = null,
				
			};

			SetNode(blueprintNode, conversionTypeNode);

			if (context.IsConverted.Value)
			{
				//var convertedModuleNode = Conversion.Metadata.Modules.Get(context.Conversion, structuralInputTypeNode.Module.VersionId);
				//conversionTypeNode.Module = convertedModuleNode;
				//conversionTypeNode.Assembly = convertedModuleNode.AssemblyNode;

				var conversion = context.Conversion;

				var underlyingType = Bound.MakeGenericType(blueprint, typeArgumentTypes);

				var converted = (ConvertedGenericTypeDefinition_I)Conversion.Metadata.Members.Types.Creation.Create(conversion.RuntimicSystem, typeReference);

				conversionTypeNode.Type = converted;

				converted.Blueprint = blueprint;

				converted.UnderlyingType = underlyingType;

				for (var j = 0; j < typeArguments.Length; j++)
				{
					var currentTypeArgument = typeArguments[j];

					converted.TypeArguments.All.Add(currentTypeArgument.Type);
				}

				

				Conversion.Metadata.Members.Types.Building.UpdateBuildPhase(converted, BuildPhaseKind.TypeDefined);

				Conversion.Metadata.Members.Types.Building.IfPossibleBuildPhase2(conversion, converted);

				return conversionTypeNode;
			}
			else
			{
				//var typeReference = (GenericInstanceType)context.TypeReference;

				// If not first, then a dependency is created by method calls needing the generic instance
				//var blueprint = (BoundGenericTypeDefinitionMask_I)Execution.Types.Ensuring.EnsureBound(context, typeReference.ElementType, cloneContext: true);

				//var typeArguments = Bound.Metadata.Members.TypeArguments.Building.Build(context, typeReference, out Type[] typeArgumentTypes);
				//var convertedModuleNode = Bound.Metadata.Modules.Getting.Get(context.RuntimicSystem, structuralInputTypeNode.Module.VersionId);
				//conversionTypeNode.Module = convertedModuleNode;
				//conversionTypeNode.Assembly = convertedModuleNode.AssemblyNode;

				var underlyingType = Bound.MakeGenericType(blueprint, typeArgumentTypes);

				var converted = (BoundGenericTypeDefinition_I)Bound.Metadata.Members.Types.Creation.Create(context.RuntimicSystem, typeReference, underlyingType);

				conversionTypeNode.Type = converted;

				converted.Blueprint = blueprint;

				converted.UnderlyingType = underlyingType;

				for (var j = 0; j < typeArguments.Length; j++)
				{
					var currentTypeArgument = typeArguments[j];

					converted.TypeArguments.All.Add(currentTypeArgument.Type);
				}

				conversionTypeNode.Type = converted;

				if (//hasGenericParameters && 
					underlyingType.IsGenericTypeDefinition)
				{
					// Check to see if effectively is a generic type definition.
					// A) Do not try to get methods for types that are generic type definitions

				}
				else
				{
					Bound.Metadata.Members.Fields.Building.Generic.BuildFields(context.RuntimicSystem, converted);

					Bound.Metadata.Members.Constructors.Building.BuildConstructors(context.RuntimicSystem, converted);

					Bound.Metadata.Members.Methods.Building.BuildMethods(context.RuntimicSystem, converted);
				}

				

				return conversionTypeNode;
			}

			
		}

		private void SetNode(ExecutionTypeNode_I arrayStemType, ExecutionGenericInstanceTypeNode node)
		{
			if (arrayStemType.Generics == null)

			{
				arrayStemType.Generics = new ExecutionGenericInstanceTypeNode[5];
			}

			var foundSlot = false;
			int currentIndex = 0;

			for (; currentIndex < arrayStemType.Generics.Length; currentIndex++)
			{
				var arrayNode = arrayStemType.Generics[currentIndex];

				if (arrayNode == null)
				{
					foundSlot = true;
					break;
				}
			}

			if (!foundSlot)
			{
				var tempArrays = new ExecutionGenericInstanceTypeNode[arrayStemType.Generics.Length + 5];

				Array.Copy(arrayStemType.Generics, 0, tempArrays, 0, arrayStemType.Generics.Length);

				arrayStemType.Generics = tempArrays;
			}

			arrayStemType.Generics[currentIndex] = node;
		}

		private bool CheckForBranch(ExecutionTypeNode_I blueprintNode, ExecutionTypeNode_I[] typeArguments,
			out ExecutionGenericInstanceTypeNode executionTypeNode)
		{
			executionTypeNode = null;

			var generics = blueprintNode.Generics;

			if (generics == null) return false;

			for (int i = 0; i < generics.Length; i++)
			{
				var genericInstanceNode = generics[i];

				if (genericInstanceNode?.Arguments?.Length != typeArguments.Length) continue;
				
				var ok = true;

				for (var j = 0; j < genericInstanceNode.Arguments.Length; j++)
				{
					var argument = genericInstanceNode.Arguments[j];

					if (ReferenceEquals(argument, typeArguments[j])) continue;

					ok = false;

					break;
				}

				if (!ok) continue;

				executionTypeNode = genericInstanceNode;

				return true;
			}

			return false;
		}
	}
}
