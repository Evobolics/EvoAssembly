using System.Linq;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Getting
{
    public class GettingApi<TContainer> : ConversionApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public FieldInfo[] GetFieldsFromCollection(BoundGenericTypeDefinitionMask_I inputBlueprint)
		{
			

			if (!(inputBlueprint is BoundTypeDefinitionWithFieldsMask_I withFields))
			{
				throw new System.Exception("GenericClassDefinition should have fields if this type has fields.");
			}

			var collection = withFields.Fields.ByName.Values.ToList();

			FieldInfo[] fields = new FieldInfo[withFields.Fields.ByName.Count];

			for (int i = 0; i < collection.Count; i++)
			{
				var semantic = collection[i];

				if (!(semantic is BoundFieldDefinitionMask_I bound))
				{
					throw new System.Exception("Semantic field should be a bound field to use it in conversion.");
				}

				fields[i] = bound.UnderlyingField;
			}

			return fields;
		}

	    public BoundFieldDefinitionMask_I GetBoundField(BoundTypeDefinitionMask_I converted, string namedArgumentName)
	    {
		    if (!(converted is BoundTypeDefinitionWithFieldsMask_I withFields))
		    {
			    throw new System.Exception($"Expected converted to be of type {typeof(BoundTypeDefinitionWithFieldsMask_I)}");
		    }

		    if (!withFields.Fields.ByName.TryGetValue(namedArgumentName, out SemanticFieldMask_I semanticField))
		    {
				throw new System.Exception($"Expected a single field named {namedArgumentName}");
			}

		    if (!(semanticField is BoundFieldDefinitionMask_I boundField))
		    {
			    throw new System.Exception($"Expected field to be of type {typeof(BoundFieldDefinitionMask_I)}");
		    }

		    return boundField;
	    }
	}
}
