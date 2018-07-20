using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeParameters
{
	public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void EnsureTypeParametersIfAny(ILConversion conversion, ConvertedTypeDefinition_I converted)
		{
			TypeReference inputType = converted.SourceTypeReference;

			if (!inputType.HasGenericParameters) return;

			var parameters = inputType.GenericParameters;

			var generic = (ConvertedGenericTypeDefinition_I)converted;

			

			for (var i = 0; i < parameters.Count; i++)
			{
				var typeParameter = CreateTypeParameter(conversion, inputType, parameters[i]);

				Types.TypeParameters.Add(conversion, generic, typeParameter);
			}

			var names = Types.TypeParameters.GetNames(conversion, generic);

			// NEED BUILDERS BEFORE C
			generic.TypeParameters.Builders = converted.TypeBuilder.DefineGenericParameters(names);

			for (var i = 0; i < parameters.Count; i++)
			{
				var typeParameter = (ConvertedGenericParameterTypeDefinition)generic.TypeParameters.All[i];

				typeParameter.Builder = generic.TypeParameters.Builders[i];

				typeParameter.UnderlyingType = typeParameter.Builder;

				var genericParameterAttributes = Cecil.Metadata.Members.GenericParameters.GetGenericParameterAttributes(typeParameter.Attributes);

				typeParameter.Builder.SetGenericParameterAttributes(genericParameterAttributes);
			}

			// DO THIS SEPERATELY, as the constraints could be self referencing, and it needs the parameters to be added to this type to find them.
			// THUS THE CREATE AND  ADD OPERATIONS NEED TO BE DONE FIRST.  This is the same reason why the add is called on ensuring before anything else.

			for (var i = 0; i < parameters.Count; i++)
			{
				var typeParameter = (ConvertedGenericParameterTypeDefinition)generic.TypeParameters.All[i];

				BuildConstraints(conversion, typeParameter);
			}

			for (var i = 0; i < parameters.Count; i++)
			{
				var typeParameter = (ConvertedGenericParameterTypeDefinition)generic.TypeParameters.All[i];

				if (typeParameter.InterfaceTypeConstraints != null && typeParameter.InterfaceTypeConstraints.Count > 0)
				{
					var interfaceTypes = GetInterfaceTypeConstraints(conversion, typeParameter.InterfaceTypeConstraints);

					typeParameter.Builder.SetInterfaceConstraints(interfaceTypes);
				}

				var baseTypeConstraint = GetBaseTypeConstraint(conversion, typeParameter.BaseTypeConstraint);

				if (baseTypeConstraint != null)
				{
					typeParameter.Builder.SetBaseTypeConstraint(baseTypeConstraint);
				}

				Types.Building.UpdateBuildPhase(typeParameter, BuildPhaseKind.TypeCreated);
			}
		}

		private void BuildConstraints(ILConversion conversion, ConvertedGenericParameterTypeDefinition typeParameter)
		{
			var typeParamterType = typeParameter.Definition;

			var constraints = typeParamterType.Constraints;

			var semanticConstraints = new BoundGenericParameterTypeDefinitionConstraintMask_I[constraints.Count];

			for (int i = 0; i < constraints.Count; i++)
			{
				var constraint = constraints[i];

				ConvertedTypeParameterConstraint semanticConstraint;

				bool isClassConstraint = IsClassConstraint(conversion, constraint);

				if (isClassConstraint)
				{
					var x = new ConvertedClassTypeParameterConstraint()
					{
						Attributes = typeParameter.Attributes,
						Class = Execution.Types.Ensuring.Ensure(conversion.Model, constraint, null, null)
					};

					typeParameter.BaseTypeConstraint = x;

					semanticConstraint = x;
				}
				else
				{
					var x = new ConvertedInterfaceTypeParameterConstraint()
					{
						Attributes = typeParameter.Attributes,
						Interface = Execution.Types.Ensuring.Ensure(conversion.Model, constraint, null, null)
					};

					semanticConstraint = x;

					typeParameter.InterfaceTypeConstraints.Add(x);
				}

				semanticConstraints[i] = semanticConstraint;
			}
		}

		public ConvertedGenericParameterTypeDefinition CreateTypeParameter(ILConversion conversion, TypeReference inputType, GenericParameter typeParamterType)
		{


			var typeParameter = new ConvertedGenericParameterTypeDefinition
			{
				Attributes = Cecil.Metadata.Members.GenericParameters.GetTypeParameterAttributes(typeParamterType),
				Name = typeParamterType.Name,
				FullName = typeParamterType.FullName,
				Position = typeParamterType.Position,
				TypeParameterKind = GetTypeParameterKind(typeParamterType.Type),
				Definition = typeParamterType
			};



			return typeParameter;
		}

		private Type GetBaseTypeConstraint(ILConversion conversion, ConvertedClassTypeParameterConstraint tpBaseTypeConstraint)
		{
			if (tpBaseTypeConstraint == null) return null;

			if (tpBaseTypeConstraint.Class == null)
			{
				throw new Exception("The class of a base type constraint should not be null.");
			}

			if (tpBaseTypeConstraint.Class.IsConverted())
			{
				ConvertedTypeDefinition_I convertedInterface = (ConvertedTypeDefinition_I)tpBaseTypeConstraint.Class;

				//if (!convertedInterface.IsBuilt)
				//{
				//	Types.Ensuring.Ensure(conversion, convertedInterface);
				//}
			}

			var result = Models.Types.GetBoundUnderlyingTypeOrThrow(tpBaseTypeConstraint.Class);

			return result;
		}

		private Type[] GetInterfaceTypeConstraints(ILConversion conversion, List<ConvertedInterfaceTypeParameterConstraint> tpInterfaceTypeConstraints)
		{
			var types = new List<Type>();

			foreach (var x in tpInterfaceTypeConstraints)
			{
				if (x.Interface == null)
				{
					throw new Exception("The interface of a constraint should not be null.");
				}

				if (x.Interface != null && x.Interface.IsConverted())
				{
					ConvertedTypeDefinition_I convertedInterface = (ConvertedTypeDefinition_I)x.Interface;

					//if (!convertedInterface.IsBuilt)
					//{
					//	Types.Ensuring.Ensure(conversion, convertedInterface);
					//}
				}

				var result = Models.Types.GetBoundUnderlyingTypeOrThrow(x.Interface);

				types.Add(result);
			}

			return types.ToArray();
		}

		private bool IsClassConstraint(ILConversion conversion, TypeReference constraint)
		{
			return Cecil.Types.IsClass(conversion.Model, constraint);

		}

		private TypeParameterKind GetTypeParameterKind(GenericParameterType type)
		{
			switch (type)
			{
				case GenericParameterType.Type:
					return TypeParameterKind.Type;
				case GenericParameterType.Method:
					return TypeParameterKind.Method;
				default:
				{
					throw new Exception(
						$"Expected either a type parameter kind of type or method, but not {type.ToString()}");
				}
			}
		}

		

		
	}
}
