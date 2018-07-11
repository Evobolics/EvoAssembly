using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
	public class DynamicallyCreatedApi<TContainer> : ConversionApiNode<TContainer>, DynamicallyCreatedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void AddAllMethodOverrides(ILConversion conversion, ConvertedTypeDefinition_I input)
		{
			// Done on purpose to find errors
			var typeDefinition = (TypeDefinition)input.SourceTypeReference;

			if (!typeDefinition.HasMethods) return;

			if (!(input is ConvertedTypeDefinitionWithMethods_I convertedTypeWithMethods))
			{
				throw new Exception("Trying to add a method to a type that does not support methods.");
			}

			var methods = Methods.Getting.GetMethods(input);

			for (int i = 0; i < methods.Count; i++)
			{
				var method = methods[i];

				AddMethodOverride(conversion, input, method);
			}
		}

		public void AddMethodOverride(ILConversion conversion, ConvertedTypeDefinitionMask_I input, BoundMethodDefinitionMask_I method)
		{
			if (!method.MethodReference.IsDefinition) return;

			var methodDefinition = (MethodDefinition) method.MethodReference;

			if (!methodDefinition.HasOverrides) return;

			for (int j = 0; j < methodDefinition.Overrides.Count; j++)
			{
				var methodOverride = methodDefinition.Overrides[j];

				var interfaceDeclaringType = Types.Ensuring.EnsureBound(conversion, methodOverride.DeclaringType);

				var semanticMethod = Methods.Getting.FindMethodByDefinition(conversion, (BoundTypeDefinitionWithMethodsMask_I)interfaceDeclaringType, (MethodDefinition)methodOverride);

				if (!(semanticMethod is BoundMethodDefinitionMask_I boundMethod))
				{
					throw new Exception("Not a bound method.  Could not add the method override.");
				}

				MethodInfo interfaceMethodInfo = boundMethod.UnderlyingMethod;

				input.TypeBuilder.DefineMethodOverride(method.UnderlyingMethod, interfaceMethodInfo);
			}
		}

		public void BuildMethods(ILConversion conversion, ConvertedTypeDefinitionMask_I input)
		{
			// Done on purpose to find errors
			var typeDefinition = (TypeDefinition)input.SourceTypeReference;

			if (!typeDefinition.HasMethods) return;

			if (!(input is ConvertedTypeDefinitionWithMethods_I convertedTypeWithMethods))
			{
				throw new Exception("Trying to add a method to a type that does not support methods.");
			}

			for (int i = 0; i < typeDefinition.Methods.Count; i++)
			{
				var method = typeDefinition.Methods[i];

				BuildMethod(conversion, convertedTypeWithMethods, method);
			}
		}

		public void BuildMethod(ILConversion conversion, ConvertedTypeDefinitionWithMethods_I input, MethodDefinition method)
		{
			if (input.IsGeneric() && input is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType())
			{
				return;
			}

			

			var methodEntry = new ConvertedBuiltMethod
			{
				MethodReference = method,
				DeclaringType = input,
				Conversion = conversion,
				MethodAttributes = BuildMethodAttributes(method),
				Name = method.Name
			};

			if (!input.Methods.ByName.TryGetValue(methodEntry.Name, out List<SemanticMethodMask_I> methods))
			{
				methods = new List<SemanticMethodMask_I>();

				input.Methods.ByName.Add(methodEntry.Name, methods);
			}

			var callingConventions = Methods.GetCallingConventions(method);

			methods.Add(methodEntry);

			methodEntry.MethodBuilder =input.TypeBuilder.DefineMethod(method.Name, methodEntry.MethodAttributes, callingConventions);

			// Needs method builder to create the generic parameters
			AddGenericParameters(conversion, input, methodEntry);

			Routines.Building.BuildRoutine(conversion, input, methodEntry);

			var runtimeReturnType = methodEntry.ReturnType.UnderlyingType;

			var systemParameterTypes = Parameters.GetSystemParameterTypes(conversion, methodEntry.Parameters.All);

			methodEntry.MethodBuilder.SetSignature(runtimeReturnType, Type.EmptyTypes, Type.EmptyTypes, systemParameterTypes, null, null);

			Routines.Building.CreateParameterBuilders(conversion, methodEntry);

			SetImplementationFlagsIfPresent(method, methodEntry.MethodBuilder);

			CustomAttributes.BuildCustomAttributes(conversion, input, methodEntry);

			if (method.MethodReturnType.HasCustomAttributes)
			{
				var returnParameter = methodEntry.MethodBuilder.DefineParameter(0, System.Reflection.ParameterAttributes.Retval, null);

				CustomAttributes.BuildCustomAttributes(conversion, returnParameter, method.MethodReturnType);
			}


		}

		public void AddGenericParameters(ILConversion conversion, ConvertedTypeDefinitionMask_I input, ConvertedBuiltMethod methodEntry)
		{
			var methodDefinition = methodEntry.MethodReference;

			if (!methodDefinition.HasGenericParameters) return;

			List<string> genericParameterNamesList = new List<string>();

			foreach (var genericParamater in methodDefinition.GenericParameters)
			{
				var genericParamaterTypeDefintionEntry = new ConvertedGenericParameterTypeDefinition()
				{
					Name = genericParamater.Name,
					DeclaringTypeDefinitionEntry = input,
					Definition = genericParamater,
					Position = genericParamater.Position,
					TypeParameterKind = TypeParameterKind.Method
				};

				genericParameterNamesList.Add(genericParamaterTypeDefintionEntry.Name);

				Methods.TypeParameters.Add(conversion, methodEntry, genericParamaterTypeDefintionEntry);


			}

			var genericParameterNames = genericParameterNamesList.ToArray();

			GenericTypeParameterBuilder[] genericTypeParameterBuilders = methodEntry.MethodBuilder.DefineGenericParameters(genericParameterNames);

			methodEntry.TypeParameters.Builders = genericTypeParameterBuilders;

			foreach (var builder in genericTypeParameterBuilders)
			{
				var name = builder.Name;

				var genericTypeParameterEntry = Methods.TypeParameters.GetOrThrow(conversion, methodEntry, name);

				var definition = genericTypeParameterEntry.Definition;

				var attributes = GetGenericParameterAttributes(definition);

				builder.SetGenericParameterAttributes(attributes);

				genericTypeParameterEntry.Builder = builder;

				if (definition.HasConstraints)
				{
					foreach (var constraint in definition.Constraints)
					{
						throw new NotImplementedException("Generic Parameter constraints not implemented yet.");
					}
				}

				genericTypeParameterEntry.UnderlyingType = builder;
			}
		}

		private static System.Reflection.GenericParameterAttributes GetGenericParameterAttributes(GenericParameter definiton)
		{
			System.Reflection.GenericParameterAttributes attributes = System.Reflection.GenericParameterAttributes.None;

			if (definiton.HasDefaultConstructorConstraint)
			{
				attributes |= System.Reflection.GenericParameterAttributes.DefaultConstructorConstraint;
			}

			if (definiton.HasReferenceTypeConstraint)
			{
				attributes |= System.Reflection.GenericParameterAttributes.ReferenceTypeConstraint;
			}

			if (definiton.IsCovariant)
			{
				attributes |= System.Reflection.GenericParameterAttributes.Covariant;
			}

			if (definiton.IsContravariant)
			{
				attributes |= System.Reflection.GenericParameterAttributes.Contravariant;
			}

			if (definiton.HasNotNullableValueTypeConstraint)
			{
				attributes |= System.Reflection.GenericParameterAttributes.NotNullableValueTypeConstraint;
			}
			return attributes;
		}

		public System.Reflection.MethodAttributes BuildMethodAttributes(MethodDefinition methodDefinition)
		{
			var newAttributes = default(System.Reflection.MethodAttributes);

			var attributes = methodDefinition.Attributes;

			if ((attributes & Mono.Cecil.MethodAttributes.Public) == Mono.Cecil.MethodAttributes.Public)
			{
				newAttributes |= System.Reflection.MethodAttributes.Public;
			}
			else if ((attributes & Mono.Cecil.MethodAttributes.Family) == Mono.Cecil.MethodAttributes.Family)
			{
				newAttributes |= System.Reflection.MethodAttributes.Family;
			}
			else if ((attributes & Mono.Cecil.MethodAttributes.FamANDAssem) == Mono.Cecil.MethodAttributes.FamANDAssem)
			{
				newAttributes |= System.Reflection.MethodAttributes.FamANDAssem;
			}
			else if ((attributes & Mono.Cecil.MethodAttributes.Private) == Mono.Cecil.MethodAttributes.Private)
			{
				newAttributes |= System.Reflection.MethodAttributes.Private;
			}
			else
			{
				if ((attributes & Mono.Cecil.MethodAttributes.Assembly) == Mono.Cecil.MethodAttributes.Assembly)
				{
					newAttributes |= System.Reflection.MethodAttributes.Assembly;
				}

				if ((attributes & Mono.Cecil.MethodAttributes.FamORAssem) == Mono.Cecil.MethodAttributes.FamORAssem)
				{
					newAttributes |= System.Reflection.MethodAttributes.FamORAssem;
				}
			}

			if ((attributes & Mono.Cecil.MethodAttributes.Abstract) == Mono.Cecil.MethodAttributes.Abstract)
			{
				newAttributes |= System.Reflection.MethodAttributes.Abstract;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.CheckAccessOnOverride) == Mono.Cecil.MethodAttributes.CheckAccessOnOverride)
			{
				newAttributes |= System.Reflection.MethodAttributes.CheckAccessOnOverride;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.Final) == Mono.Cecil.MethodAttributes.Final)
			{
				newAttributes |= System.Reflection.MethodAttributes.Final;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.HasSecurity) == Mono.Cecil.MethodAttributes.HasSecurity)
			{
				newAttributes |= System.Reflection.MethodAttributes.HasSecurity;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.HideBySig) == Mono.Cecil.MethodAttributes.HideBySig)
			{
				newAttributes |= System.Reflection.MethodAttributes.HideBySig;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.NewSlot) == Mono.Cecil.MethodAttributes.NewSlot)
			{
				newAttributes |= System.Reflection.MethodAttributes.NewSlot;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.PInvokeImpl) == Mono.Cecil.MethodAttributes.PInvokeImpl)
			{
				newAttributes |= System.Reflection.MethodAttributes.PinvokeImpl;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.RequireSecObject) == Mono.Cecil.MethodAttributes.RequireSecObject)
			{
				newAttributes |= System.Reflection.MethodAttributes.RequireSecObject;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.ReuseSlot) == Mono.Cecil.MethodAttributes.ReuseSlot)
			{
				newAttributes |= System.Reflection.MethodAttributes.ReuseSlot;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.RTSpecialName) == Mono.Cecil.MethodAttributes.RTSpecialName)
			{
				newAttributes |= System.Reflection.MethodAttributes.RTSpecialName;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.SpecialName) == Mono.Cecil.MethodAttributes.SpecialName)
			{
				newAttributes |= System.Reflection.MethodAttributes.SpecialName;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.Static) == Mono.Cecil.MethodAttributes.Static)
			{
				newAttributes |= System.Reflection.MethodAttributes.Static;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.UnmanagedExport) == Mono.Cecil.MethodAttributes.UnmanagedExport)
			{
				newAttributes |= System.Reflection.MethodAttributes.UnmanagedExport;
			}

			if ((attributes & Mono.Cecil.MethodAttributes.Virtual) == Mono.Cecil.MethodAttributes.Virtual)
			{
				newAttributes |= System.Reflection.MethodAttributes.Virtual;
			}

			return newAttributes;
		}

		public void SetImplementationFlagsIfPresent(MethodDefinition methodDefintion, MethodBuilder methodBuilder)
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
				methodBuilder.SetImplementationFlags(methodImplFlags);
			}
		}
	}
}
