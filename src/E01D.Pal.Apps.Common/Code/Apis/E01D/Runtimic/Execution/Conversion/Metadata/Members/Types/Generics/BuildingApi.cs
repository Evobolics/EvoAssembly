using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Generics
{
	public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public Type[] Build(ILConversion conversion, ConvertedTypeDefinition converted)
		{
			if (!converted.IsGeneric()) return Type.EmptyTypes;

			GenericInstanceType inputType = (GenericInstanceType)converted.SourceTypeReference;

			var list = new List<SemanticTypeDefinitionMask_I>();

			if (inputType.GenericArguments.Count <= 0) return Type.EmptyTypes;

			Type[] types = new Type[inputType.GenericArguments.Count];

			bool hasGenericParametersAsTypeArguments = false;

			for (var i = 0; i < inputType.GenericArguments.Count; i++)
			{
				var genericArgument = inputType.GenericArguments[i];

				var semanticType = Execution.Types.Ensuring.Ensure(conversion.Model, genericArgument, null, null);

				if (!(semanticType is BoundTypeDefinitionMask_I bound))
				{
					throw new System.Exception("Semantic type needs to be a bound type.");
				}

				types[i] = bound.UnderlyingType;

				hasGenericParametersAsTypeArguments |= types[i].IsGenericParameter;

				list.Add(Models.Types.GetBoundTypeOrThrow(semanticType, false));
			}

			ConvertedGenericTypeDefinition_I generic = (ConvertedGenericTypeDefinition_I)converted;

			generic.TypeArguments.All = list;
			//generic.TypeArguments.HasGenericParametersAsTypeArguments = hasGenericParametersAsTypeArguments;

			return types;
		}
	}
}
