using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using MethodAttributes = Root.Code.Libs.Mono.Cecil.MethodAttributes;

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

			if (!(input is ConvertedTypeWithMethods_I convertedTypeWithMethods))
			{
				throw new Exception("Trying to add a method to a type that does not support methods.");
			}

			var methods = Bound.Metadata.Members.Methods.Getting.GetMethods(input);

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

				var interfaceDeclaringType = Execution.Types.Ensuring.EnsureBound(conversion.Model, methodOverride.DeclaringType);

				if (!(methodOverride is MethodDefinition methodOverrideDefinition))
				{
					methodOverrideDefinition = Cecil.Metadata.Members.Methods.ResolveReferenceToNonSignatureDefinition(conversion.Model, methodOverride);
				}

				var semanticMethod = Bound.Metadata.Members.Methods.Getting.FindMethodByDefinition(conversion.Model, (BoundTypeDefinitionWithMethodsMask_I)interfaceDeclaringType, methodOverrideDefinition);

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

			if (!(input is ConvertedTypeWithMethods_I convertedTypeWithMethods))
			{
				throw new Exception("Trying to add a method to a type that does not support methods.");
			}

			for (int i = 0; i < typeDefinition.Methods.Count; i++)
			{
				var method = typeDefinition.Methods[i];

				BuildMethod(conversion, convertedTypeWithMethods, method);
			}
		}

		public void BuildMethod(ILConversion conversion, ConvertedTypeWithMethods_I input, MethodDefinition method)
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

				var genericParamaterTypeDefintionEntry = (ConvertedGenericParameterTypeDefinition)
					Execution.Metadata.Members.Types.Ensuring.Ensure(conversion.Model, new BoundEnsureContext()
				{
					TypeReference = genericParamater,
					MethodReference = methodDefinition
				});

				

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
					List<Type> interfaceConstraintTypes = new List<Type>();

					foreach (var constraint in definition.Constraints)
					{
						bool isClassConstraint = Cecil.Types.IsClass(conversion.Model, constraint);

						var semanticConstraint =Execution.Types.Ensuring.EnsureBound(conversion.Model, constraint, null);

						if (isClassConstraint)
						{
							builder.SetBaseTypeConstraint(semanticConstraint.UnderlyingType);
						}
						else
						{
							interfaceConstraintTypes.Add(semanticConstraint.UnderlyingType);
						}
					}

					if (interfaceConstraintTypes.Count > 0)
					{
						builder.SetInterfaceConstraints(interfaceConstraintTypes.ToArray());
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

			if ((attributes & MethodAttributes.Public) == MethodAttributes.Public)
			{
				newAttributes |= System.Reflection.MethodAttributes.Public;
			}
			else if ((attributes & MethodAttributes.Family) == MethodAttributes.Family)
			{
				newAttributes |= System.Reflection.MethodAttributes.Family;
			}
			else if ((attributes & MethodAttributes.FamANDAssem) == MethodAttributes.FamANDAssem)
			{
				newAttributes |= System.Reflection.MethodAttributes.FamANDAssem;
			}
			else if ((attributes & MethodAttributes.Private) == MethodAttributes.Private)
			{
				newAttributes |= System.Reflection.MethodAttributes.Private;
			}
			else
			{
				if ((attributes & MethodAttributes.Assembly) == MethodAttributes.Assembly)
				{
					newAttributes |= System.Reflection.MethodAttributes.Assembly;
				}

				if ((attributes & MethodAttributes.FamORAssem) == MethodAttributes.FamORAssem)
				{
					newAttributes |= System.Reflection.MethodAttributes.FamORAssem;
				}
			}

			if ((attributes & MethodAttributes.Abstract) == MethodAttributes.Abstract)
			{
				newAttributes |= System.Reflection.MethodAttributes.Abstract;
			}

			if ((attributes & MethodAttributes.CheckAccessOnOverride) == MethodAttributes.CheckAccessOnOverride)
			{
				newAttributes |= System.Reflection.MethodAttributes.CheckAccessOnOverride;
			}

			if ((attributes & MethodAttributes.Final) == MethodAttributes.Final)
			{
				newAttributes |= System.Reflection.MethodAttributes.Final;
			}

			if ((attributes & MethodAttributes.HasSecurity) == MethodAttributes.HasSecurity)
			{
				newAttributes |= System.Reflection.MethodAttributes.HasSecurity;
			}

			if ((attributes & MethodAttributes.HideBySig) == MethodAttributes.HideBySig)
			{
				newAttributes |= System.Reflection.MethodAttributes.HideBySig;
			}

			if ((attributes & MethodAttributes.NewSlot) == MethodAttributes.NewSlot)
			{
				newAttributes |= System.Reflection.MethodAttributes.NewSlot;
			}

			if ((attributes & MethodAttributes.PInvokeImpl) == MethodAttributes.PInvokeImpl)
			{
				newAttributes |= System.Reflection.MethodAttributes.PinvokeImpl;
			}

			if ((attributes & MethodAttributes.RequireSecObject) == MethodAttributes.RequireSecObject)
			{
				newAttributes |= System.Reflection.MethodAttributes.RequireSecObject;
			}

			if ((attributes & MethodAttributes.ReuseSlot) == MethodAttributes.ReuseSlot)
			{
				newAttributes |= System.Reflection.MethodAttributes.ReuseSlot;
			}

			if ((attributes & MethodAttributes.RTSpecialName) == MethodAttributes.RTSpecialName)
			{
				newAttributes |= System.Reflection.MethodAttributes.RTSpecialName;
			}

			if ((attributes & MethodAttributes.SpecialName) == MethodAttributes.SpecialName)
			{
				newAttributes |= System.Reflection.MethodAttributes.SpecialName;
			}

			if ((attributes & MethodAttributes.Static) == MethodAttributes.Static)
			{
				newAttributes |= System.Reflection.MethodAttributes.Static;
			}

			if ((attributes & MethodAttributes.UnmanagedExport) == MethodAttributes.UnmanagedExport)
			{
				newAttributes |= System.Reflection.MethodAttributes.UnmanagedExport;
			}

			if ((attributes & MethodAttributes.Virtual) == MethodAttributes.Virtual)
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
