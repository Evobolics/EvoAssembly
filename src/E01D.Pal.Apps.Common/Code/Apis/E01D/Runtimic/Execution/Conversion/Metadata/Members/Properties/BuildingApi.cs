using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
    where TContainer : RuntimicContainer_I<TContainer>
    {
        public void BuildsProperties(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            // Done on purpose to find errors
            var typeDefinition = (TypeDefinition)input.SourceTypeReference;
            
            if (!typeDefinition.HasProperties) return;

	        if (!(input is ConvertedTypeDefinitionWithProperties_I inputWithProperties))
	        {
		        throw new System.Exception("Expected a type that can store properties.");
	        }

            for (int i = 0; i < typeDefinition.Properties.Count; i++)
            {
                var property1 = typeDefinition.Properties[i];

                BuildProperty(conversion, inputWithProperties, property1);
            }
        }

        private void BuildProperty(ILConversion conversion, ConvertedTypeDefinitionWithProperties_I convertedType, PropertyDefinition propertyDefinition)
        {
			var propertyAttributes = GetPropertyAttributes(propertyDefinition);

	        var propertyType = Execution.Types.Ensuring.EnsureToType(conversion, propertyDefinition.PropertyType);

			var parameterTypes = Parameters.GetSystemParameterTypes(conversion, propertyDefinition.Parameters);

	        var builder = convertedType.TypeBuilder.DefineProperty(propertyDefinition.Name, propertyAttributes, propertyType, parameterTypes);

	        var entry = new ConvertedProperty()
	        {
				Name = propertyDefinition.Name,
				Builder = builder,
		        UnderlyingPropertyInfo = builder,
				PropertyDefinition = propertyDefinition
			};

	        if (!convertedType.Properties.ByName.TryGetValue(entry.Name, out List<SemanticPropertyMask_I> propertyList))
	        {
		        propertyList = new List<SemanticPropertyMask_I>();

		        convertedType.Properties.ByName.Add(entry.Name, propertyList);
	        }

	        propertyList.Add(entry);

	        if (propertyDefinition.GetMethod != null)
	        {
		        ConvertedMethodMask_I getMethod = Methods.Getting.GetMethod(convertedType, propertyDefinition.GetMethod);

		        if (getMethod?.UnderlyingMethod == null)
		        {
			        throw new System.Exception("Expected get method");
		        }

		        builder.SetGetMethod((MethodBuilder)getMethod.UnderlyingMethod);
	        }

	        if (propertyDefinition.SetMethod != null)
	        {
		        ConvertedMethodMask_I setMethod = Methods.Getting.GetMethod(convertedType, propertyDefinition.SetMethod);

		        if (setMethod?.UnderlyingMethod == null)
		        {
			        throw new System.Exception("Expected set method");
		        }

		        builder.SetSetMethod((MethodBuilder)setMethod.UnderlyingMethod);
	        }

	        CustomAttributes.BuildCustomAttributes(conversion, convertedType, entry);
		}

	    

	   

		private System.Reflection.PropertyAttributes GetPropertyAttributes(PropertyDefinition propertyDefinition)
	    {
		    System.Reflection.PropertyAttributes attributes = System.Reflection.PropertyAttributes.None;

		    var cecilAttributes = propertyDefinition.Attributes;

		    if ((cecilAttributes & PropertyAttributes.HasDefault)== PropertyAttributes.HasDefault)
		    {
			    attributes |= System.Reflection.PropertyAttributes.HasDefault;
		    }
		    if ((cecilAttributes & PropertyAttributes.RTSpecialName) == PropertyAttributes.RTSpecialName)
		    {
			    attributes |= System.Reflection.PropertyAttributes.RTSpecialName;
		    }
		    if ((cecilAttributes & PropertyAttributes.SpecialName) == PropertyAttributes.SpecialName)
		    {
			    attributes |= System.Reflection.PropertyAttributes.SpecialName;
		    }

		    return attributes;
	    }
	}
}
