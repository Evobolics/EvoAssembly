﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.TypeArguments
{
	public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		//public Type[] Build(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
		//{
		//	if (!converted.IsGeneric()) return Type.EmptyTypes;

		//	GenericInstanceType inputType = (GenericInstanceType)converted.SourceTypeReference;

		//	var list = new List<SemanticTypeDefinitionMask_I>();

		//	if (inputType.GenericArguments.Count <= 0) return Type.EmptyTypes;

		//	Type[] types = new Type[inputType.GenericArguments.Count];

			

		//	for (var i = 0; i < inputType.GenericArguments.Count; i++)
		//	{
		//		var genericArgument = inputType.GenericArguments[i];

		//		var semanticType = Execution.Types.Ensuring.Ensure(conversion.Model, genericArgument, null, null);

		//		if (!(semanticType is BoundTypeDefinitionMask_I bound))
		//		{
		//			throw new System.Exception("Semantic type needs to be a bound type.");
		//		}

		//		types[i] = bound.UnderlyingType;

		//		hasGenericParametersAsTypeArguments |= types[i].IsGenericParameter;

		//		list.Add(Models.Types.GetBoundTypeOrThrow(semanticType, false));
		//	}

		//	ConvertedGenericTypeDefinition_I generic = (ConvertedGenericTypeDefinition_I)converted;

		//	generic.TypeArguments.All = list;
		//	//generic.TypeArguments.HasGenericParametersAsTypeArguments = hasGenericParametersAsTypeArguments;

		//	return types;
		//}

		
	}
}
