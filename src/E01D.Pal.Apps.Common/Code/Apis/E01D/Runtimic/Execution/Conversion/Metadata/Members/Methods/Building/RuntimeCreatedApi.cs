using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
	public class RuntimeCreatedApi<TContainer> : ConversionApiNode<TContainer>, RuntimeCreatedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildMethods(ILConversion conversion, ConvertedGenericTypeDefinition_I input)
		{
			if (!(input is BoundTypeDefinitionWithMethodsMask_I convertedTypeWithMethods))
			{
				return;
			}

			if (input.UnderlyingType.IsGenericTypeDefinition)
			{
				throw new System.Exception("You cannot call a method that is part of a generic type definition.  Using this method info will cause a method invocation exeception. ");
			}

			var blueprintMethods = Bound.Metadata.Members.Methods.Getting.GetMethods(input.Blueprint);

			for (int i = 0; i < blueprintMethods.Count; i++)
			{
				var blueprintMethod = blueprintMethods[i];

				var blueprintUnderlyingMethodInfo = blueprintMethod.UnderlyingMethod;

				// This MUST use typebuilder.GetMethod and not
				// input.Blueprint.UnderlyingType, as different MethodInfo objects are returned.
				var genericInstanceMethodInfo = TypeBuilder.GetMethod(input.UnderlyingType, blueprintUnderlyingMethodInfo);
			
				var methodDefinition = (MethodDefinition)blueprintMethod.MethodReference;

				var methodReference = Cecil.Methods.Building.MethodDefinitions.
					MakeGenericInstanceTypeMethodReference(conversion.Model, (GenericInstanceType)input.SourceTypeReference, methodDefinition);

				var methodEntry = BuildMethod(conversion, input, genericInstanceMethodInfo, methodReference);

				AddMethodToConverted(convertedTypeWithMethods, methodEntry);
			}
		}

		private void AddMethodToConverted(BoundTypeDefinitionWithMethodsMask_I convertedTypeWithMethods,
			ConvertedMethod methodEntry)
		{
			if (!convertedTypeWithMethods.Methods.ByName.TryGetValue(methodEntry.Name, out List<SemanticMethodMask_I> methodList))
			{
				methodList = new List<SemanticMethodMask_I>();

				convertedTypeWithMethods.Methods.ByName.Add(methodEntry.Name, methodList);
			}

			methodList.Add(methodEntry);
		}


		/// <summary>
		/// The goal here is to get the method definition that corresponds to the method
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="declaringType"></param>
		/// <param name="declaringTypeReference"></param>
		/// <param name="declaringTypeDefinition"></param>
		/// <param name="method"></param>
		private ConvertedMethod BuildMethod(ILConversion conversion, ConvertedTypeDefinitionMask_I declaringType, MethodInfo method, MethodReference methodReference)
		{
			ConvertedMethod methodEntry;

			var genericArguments = method.GetGenericArguments();

			// ReSharper disable once ConstantConditionalAccessQualifier - IT CAN BE NULL.
			if (genericArguments?.Length > 0)
			{
				methodEntry = new ConvertedGenericMethod
				{
					MethodReference = methodReference,
					DeclaringType = declaringType,
					Conversion = conversion,
					MethodAttributes = method.Attributes,
					Name = method.Name,
					UnderlyingMethod = method
				};
			}
			else
			{
				methodEntry = new ConvertedBoundMethod
				{
					MethodReference = methodReference,
					DeclaringType = declaringType,
					Conversion = conversion,
					MethodAttributes = method.Attributes,
					Name = method.Name,
					UnderlyingMethod = method
				};
			}

			return methodEntry;

		}


		
	}
}
