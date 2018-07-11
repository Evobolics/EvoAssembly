using System;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building
{
	public class EmittedApi<TContainer> : ConversionApiNode<TContainer>, EmittedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildConstructor(ILConversion conversion, ConvertedTypeDefinitionMask_I input, MethodDefinition methodDefinition)
		{
			if (!(input is ConvertedTypeDefinitionWithConstructors_I typeWithConstructors))
			{
				throw new Exception("Trying to build a field on a type that does not support fields.");
			}

			ConstructorBuilder constructorBuilder;

			var constructorEntry = new ConvertedEmittedConstructor()
			{
				Conversion = conversion,
				DeclaringType = input,
				MethodReference = methodDefinition
			};

			Routines.Building.BuildRoutine(conversion, input, constructorEntry);

			// ReSharper disable once AssignmentInConditionalExpression
			if (constructorEntry.IsStaticConstructor = (methodDefinition.Name == ConstructorInfo.TypeConstructorName))
			{
				constructorBuilder = typeWithConstructors.TypeBuilder.DefineTypeInitializer();
			}
			// ReSharper disable once AssignmentInConditionalExpression
			else if (constructorEntry.IsInstanceConstructor = (methodDefinition.Name == ConstructorInfo.ConstructorName))
			{
				var constructorAttributes = GetConstructorAttributes(methodDefinition);

				var callConventions = Methods.GetCallingConventions(methodDefinition);

				var systemParameterTypes = Parameters.GetSystemParameterTypes(conversion, constructorEntry.Parameters.All);

				constructorBuilder = typeWithConstructors.TypeBuilder.DefineConstructor(constructorAttributes, callConventions, systemParameterTypes);
			}
			else
			{
				throw new Exception("Expected a method definition marked as a constructor.");
			}



			constructorEntry.ConstructorBuilder = constructorBuilder;

			Routines.Building.CreateParameterBuilders(conversion, constructorEntry);

			SetImplementationFlagsIfPresent(methodDefinition, constructorBuilder);

			typeWithConstructors.Constructors.All.Add(constructorEntry);

			CustomAttributes.BuildCustomAttributes(conversion, input, constructorEntry);


		}

		public void SetImplementationFlagsIfPresent(MethodDefinition methodDefintion, ConstructorBuilder constructorBuilder)
		{
			System.Reflection.MethodImplAttributes methodImplFlags = default(System.Reflection.MethodImplAttributes);
			bool setFlags = false;

			if (methodDefintion.IsRuntime)
			{
				methodImplFlags |= System.Reflection.MethodImplAttributes.Runtime;

				setFlags = true;
			}

			if (methodDefintion.IsManaged)
			{
				methodImplFlags |= System.Reflection.MethodImplAttributes.Managed;

				setFlags = true;
			}

			if (setFlags)
			{
				//methodDefintion.IsManaged;
				constructorBuilder.SetImplementationFlags(methodImplFlags);
			}
		}

		public System.Reflection.MethodAttributes GetConstructorAttributes(MethodDefinition methodDefinition)
		{
			var attributes = default(System.Reflection.MethodAttributes);

			if (methodDefinition.IsPublic)
			{
				attributes |= System.Reflection.MethodAttributes.Public;
			}

			if (methodDefinition.IsFamily)
			{
				attributes |= System.Reflection.MethodAttributes.Family;
			}

			if (methodDefinition.IsHideBySig)
			{
				attributes |= System.Reflection.MethodAttributes.HideBySig;
			}

			if (methodDefinition.IsRuntimeSpecialName)
			{
				attributes |= System.Reflection.MethodAttributes.RTSpecialName;
			}

			if (methodDefinition.IsSpecialName)
			{
				attributes |= System.Reflection.MethodAttributes.SpecialName;
			}

			if (methodDefinition.IsStatic)
			{
				attributes |= System.Reflection.MethodAttributes.Static;
			}

			return attributes;
		}
	}
}
