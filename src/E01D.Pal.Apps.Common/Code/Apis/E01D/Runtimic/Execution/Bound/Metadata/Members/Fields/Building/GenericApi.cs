using System.Linq;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields.Building
{
	/// <summary>
	/// Used for building fields that potentially have generic fields.
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
    public class GenericApi<TContainer> : BoundApiNode<TContainer>, GenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public void Build()
	    {
		    
	    }
        // go through each field, and check if the field definition has a reference to a gneric parameter, and replace it.
	    public void BuildFields(RuntimicSystemModel semanticModel, BoundGenericTypeDefinition_I converted)
	    {
		    if (!(converted is BoundTypeDefinitionWithFields_I typeWithFields))
		    {
			    return;
		    }

			var allFields = converted.UnderlyingType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

		    for (int i = 0; i < allFields.Length; i++)
		    {
			    var field = allFields[i];

			    BuildField(semanticModel, typeWithFields, field);
		    }
		}

	    public void BuildFields_WithGenericTypeParameters(RuntimicSystemModel semanticModel, BoundGenericTypeDefinition_I input, BoundGenericTypeDefinitionMask_I blueprint)
	    {
		    if (!(input is BoundTypeDefinitionWithFieldsMask_I typeWithFields))
		    {
			    return;
		    }

			if (!(blueprint is BoundTypeDefinitionWithFieldsMask_I bound))
		    {
			    return;
		    }

		    var list = bound.Fields.ByName.Values.ToList();

			for (int i = 0; i < list.Count; i++)
		    {
			    var field = list[i];

			    typeWithFields.Fields.ByName.Add(field.Name, field);
			}
	    }

	    

		private void BuildField(RuntimicSystemModel semanticModel, BoundTypeDefinitionWithFields_I typeWithFields, FieldInfo fieldInfo)
	    {
			var convertedField = new BoundField()
		    {
			    FieldType = null,
			    UnderlyingField = fieldInfo,
			    Name = fieldInfo.Name,
		    };

		    typeWithFields.Fields.ByName.Add(convertedField.Name, convertedField);


		}
    }
}
