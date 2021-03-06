﻿using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Building
{
	/// <summary>
	/// Used for building fields that potentially have generic fields.
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
    public class GenericApi<TContainer> : ConversionApiNode<TContainer>, GenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    
        // go through each field, and check if the field definition has a reference to a gneric parameter, and replace it.
	    public void BuildFields(ILConversion conversion, ConvertedGenericTypeDefinition_I converted)
	    {
		    if (!(converted is ConvertedTypeDefinitionWithFields_I typeWithFields))
		    {
			    return;
		    }

		    FieldInfo[] fields = Fields.Getting.GetFieldsFromCollection(converted.Blueprint);

		    for (int i = 0; i < fields.Length; i++)
		    {
			    var field = fields[i];

				var newTypeCreated = converted.UnderlyingType;

				field = TypeBuilder.GetField(newTypeCreated, field);
			    
			    var fieldEntry = BuildField(conversion, converted, field);

			    typeWithFields.Fields.ByName.Add(fieldEntry.Name, fieldEntry);
		    }	
		}

		private ConvertedField  BuildField(ILConversion conversion, ConvertedGenericTypeDefinition_I converted, FieldInfo fieldInfo)
	    {
			
			return new ConvertedField()
		    {
			    FieldType = null,
			    Conversion = conversion,
			    UnderlyingField = fieldInfo,
			    Name = fieldInfo.Name,
		    };

		    


		}
    }
}
