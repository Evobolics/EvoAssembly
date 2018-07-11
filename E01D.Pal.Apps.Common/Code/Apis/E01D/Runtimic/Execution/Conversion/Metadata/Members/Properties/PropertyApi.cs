using System.Collections.Generic;
using System.Linq;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties
{
	public class PropertyApi<TContainer> : ConversionApiNode<TContainer>, PropertyApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I PropertyApiMask_I.Building => Building;

        public TypeScanningApi_I<TContainer> TypeScanning { get; set; }
	    

	    TypeScanningApiMask_I PropertyApiMask_I.TypeScanning => TypeScanning;

	    public BoundPropertyDefinitionMask_I GetBoundProperty(BoundTypeDefinitionMask_I converted, string namedArgumentName)
	    {
		    if (!(converted is BoundTypeDefinitionWithPropertiesMask_I withProperties))
		    {
			    throw new System.Exception($"Expected converted to be of type {typeof(BoundTypeDefinitionWithPropertiesMask_I)}");
		    }

		    if (!withProperties.Properties.ByName.TryGetValue(namedArgumentName, out List<SemanticPropertyMask_I> list))
		    {
			    throw new System.Exception($"Expected a single property named {namedArgumentName}");
		    }

		    if (list.Count == 0)
		    {
			    throw new System.Exception($"Expected a single property named {namedArgumentName}.  List was empty.");
		    }

			if (list.Count > 1)
		    {
				throw new System.Exception($"Expected a single property named {namedArgumentName}.  Found more than one.");
			}

			if (!(list[0] is BoundPropertyDefinitionMask_I boundProperty))
			{
				throw new System.Exception($"Expected property to be of type {typeof(BoundPropertyDefinitionMask_I)}");
			}

		    return boundProperty;
	    }
	}
}
