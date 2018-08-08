using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public class GenericInstanceApi<TContainer> : ConversionApiNode<TContainer>, GenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

	    

		public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion,  GenericInstanceType input, SemanticTypeDefinitionMask_I declaringType)
        {
	        var typeArguments = Bound.Metadata.Members.TypeArguments.Building.Build(conversion.RuntimicSystem, input);

	        var blueprint = (BoundGenericTypeDefinitionMask_I)Execution.Types.Ensuring.EnsureBound(conversion, input.ElementType, null);

	        if (IfAlreadyCreatedReturn(blueprint, typeArguments, out SemanticTypeDefinitionMask_I ensure)) return ensure;

	        var typeArgumentTypes = GetTypes(typeArguments, out bool hasGenericParameters);

	        var underlyingType = Bound.MakeGenericType(blueprint, typeArgumentTypes);

	        var converted = (ConvertedGenericTypeDefinition_I)Types.Creation.Create(conversion.RuntimicSystem, input);

	        converted.Blueprint = blueprint;

	        blueprint.Instances.Add(converted);

	        converted.UnderlyingType = underlyingType;

			for (var j = 0; j < typeArguments.Length; j++)
	        {
		        var currentTypeArgument = typeArguments[j];

		        converted.TypeArguments.All.Add(currentTypeArgument);
	        }

	        Types.Building.UpdateBuildPhase(converted, BuildPhaseKind.TypeDefined);

			Types.Building.IfPossibleBuildPhase2(conversion, converted);

            return converted;
        }


		private Type[] GetTypes(BoundTypeDefinitionMask_I[] typeArguments, out bool hasGenericParameters)
		{
			Type[] result = new Type[typeArguments.Length];

			hasGenericParameters = false;

			for (var j = 0; j < typeArguments.Length; j++)
			{
				var currentTypeArgument = typeArguments[j];

				hasGenericParameters |= currentTypeArgument.SourceTypeReference.IsGenericParameter;

				result[j] = currentTypeArgument.UnderlyingType;
			}

			return result;
		}




		

	    private bool IfAlreadyCreatedReturn(BoundGenericTypeDefinitionMask_I genericBlueprint, BoundTypeDefinitionMask_I[] typeArgumentTypes, out SemanticTypeDefinitionMask_I ensure)
	    {
		    for (int i = 0; i < genericBlueprint.Instances.Count; i++)
		    {
			    var instance = genericBlueprint.Instances[i];

			    var currentInstance = (BoundGenericTypeDefinitionMask_I)instance;

			    var found = true;

			    for (var j = 0; j < currentInstance.TypeArguments.All.Count; j++)
			    {
				    var currentTypeArgument = currentInstance.TypeArguments.All[j];

				    if (ReferenceEquals(currentTypeArgument, typeArgumentTypes[j])) continue;

				    found = false;

				    break;
			    }

			    if (found)
			    {
				    ensure = currentInstance;
				    return true;
			    }
		    }
		    ensure = null;
		    return false;
	    }
	}
}
