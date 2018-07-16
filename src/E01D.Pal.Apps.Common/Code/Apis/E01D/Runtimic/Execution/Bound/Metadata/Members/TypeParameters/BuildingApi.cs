using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters
{
	public class BuildingApi<TContainer> : BoundApiNode<TContainer>, BuildingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void EnsureTypeParametersIfAny(BoundRuntimicModelMask_I model, BoundTypeDefinition converted)
		{
			TypeReference inputType = converted.SourceTypeReference;

			if (!inputType.HasGenericParameters) return;

			var parameters = inputType.GenericParameters;

			var generic = (BoundGenericTypeDefinition_I)converted;

			Type[] typeArguments = converted.UnderlyingType.GetGenericArguments();

			for (var i = 0; i < parameters.Count; i++)
			{
				var typeParameter = CreateTypeParameter(model, typeArguments, inputType, parameters[i]);

				Members.TypeParameters.Add(model, generic.TypeParameters, typeParameter);
			}

			// DO THIS SEPERATELY, as the constraints could be self referencing, and it needs the parameters to be added to this type to find them.
			// THUS THE CREATE AND  ADD OPERATIONS NEED TO BE DONE FIRST.  This is the same reason why the add is called on ensuring before anything else.
			for (var i = 0; i < parameters.Count; i++)
			{
				var typeParameter = (BoundGenericParameterTypeDefinition)generic.TypeParameters.All[i];

				BuildConstraints(model, typeParameter);
			}

			for (var i = 0; i < parameters.Count; i++)
			{
				var typeParameter = (BoundGenericParameterTypeDefinition)generic.TypeParameters.All[i];

				//if (typeParameter.InterfaceTypeConstraints != null && typeParameter.InterfaceTypeConstraints.Count > 0)
				//{
				//	GetInterfaceTypeConstraints(model, typeParameter.InterfaceTypeConstraints);
				//}

				//GetBaseTypeConstraint(model, typeParameter.BaseTypeConstraint);

			}
		}

		private void BuildConstraints(BoundRuntimicModelMask_I model, BoundGenericParameterTypeDefinition typeParameter)
		{
			var typeParamterType = typeParameter.Definition;

			var constraints = typeParamterType.Constraints;

			var semanticConstraints = new BoundGenericParameterTypeDefinitionConstraintMask_I[constraints.Count];

			for (int i = 0; i < constraints.Count; i++)
			{
				var constraint = constraints[i];

				BoundGenericParameterTypeDefinitionConstraint semanticConstraint;

				bool isClassConstraint = IsClassConstraint(model, constraint);

				if (isClassConstraint)
				{
					var x = new BoundClassTypeParameterConstraint()
					{
						Attributes = typeParameter.Attributes,
						Class = Models.Types.ResolveToBound(model, constraint)
					};

					typeParameter.BaseTypeConstraint = x;

					semanticConstraint = x;
				}
				else
				{
					var x = new BoundInterfaceTypeParameterConstraint()
					{
						Attributes = typeParameter.Attributes,
						Interface = Models.Types.ResolveToBound(model, constraint)
					};

					semanticConstraint = x;

					typeParameter.InterfaceTypeConstraints.Add(x);
				}

				semanticConstraints[i] = semanticConstraint;
			}
		}

		private Type FindMatchingType(Type[] types, TypeReference typeParameter)
		{
			for (var i = 0; i < types.Length; i++)
			{
				var type = types[i];

				if (type.Name == typeParameter.Name)
				{
					return type;
				}
			}

			throw new Exception("Could not find type.");
		}

		public BoundGenericParameterTypeDefinition CreateTypeParameter(InfrastructureRuntimicModelMask_I conversion, Type[] typeArguments, TypeReference inputType, Mono.Cecil.GenericParameter typeParamterType)
		{


			var typeParameter = new BoundGenericParameterTypeDefinition
			{
				Attributes = Cecil.Metadata.Members.GenericParameters.GetTypeParameterAttributes(typeParamterType),
				Name = typeParamterType.Name,
				FullName = typeParamterType.FullName,
				Position = typeParamterType.Position,
				TypeParameterKind = GetTypeParameterKind(typeParamterType.Type),
				Definition = typeParamterType
			};

			typeParameter.UnderlyingType = FindMatchingType(typeArguments, typeParamterType);

			

			return typeParameter;
		}

		//private Type GetBaseTypeConstraint(SemanticModelMask_I conversion, BoundClassTypeParameterConstraint tpBaseTypeConstraint)
		//{
		//	if (tpBaseTypeConstraint == null) return null;

		//	if (tpBaseTypeConstraint.Class == null)
		//	{
		//		throw new Exception("The class of a base type constraint should not be null.");
		//	}

			

		//	var result = Models.Types.GetBoundUnderlyingTypeOrThrow(tpBaseTypeConstraint.Class);

		//	return result;
		//}

		//private Type[] GetInterfaceTypeConstraints(SemanticModelMask_I conversion, List<BoundInterfaceTypeParameterConstraint> tpInterfaceTypeConstraints)
		//{
		//	var types = new List<Type>();

		//	foreach (var x in tpInterfaceTypeConstraints)
		//	{
		//		if (x.Interface == null)
		//		{
		//			throw new Exception("The interface of a constraint should not be null.");
		//		}

				

		//		var result = Models.Types.GetBoundUnderlyingTypeOrThrow(x.Interface);

		//		types.Add(result);
		//	}

		//	return types.ToArray();
		//}

		private bool IsClassConstraint(InfrastructureRuntimicModelMask_I model, TypeReference constraint)
		{
			return Infrastructure.Structural.Cecil.Types.IsClass(model, constraint);

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
