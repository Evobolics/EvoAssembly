using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.CustomAttributes
{
    public class CustomAttributeApi<TContainer> : ConversionApiNode<TContainer>, CustomAttributeApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinitionMask_I input, ConvertedEmittedConstructor constructorEntry)
	    {
		    var methodDefinition = (MethodDefinition)constructorEntry.MethodReference;

			var builders = CreateCustomAttributeList(conversion, methodDefinition.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

			    constructorEntry.ConstructorBuilder.SetCustomAttribute(builder1);
		    }
		}

	    public void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinitionWithEvents_I converted, ConvertedEvent entry)
	    {
			var eventDefinition = entry.EventDefinition;

		    var builders = CreateCustomAttributeList(conversion, eventDefinition.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

			    entry.Builder.SetCustomAttribute(builder1);
		    }
		}

	    public void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinition_I input, ConvertedField convertedField)
	    {
		    var builders = CreateCustomAttributeList(conversion, convertedField.FieldDefinition.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

			    convertedField.FieldBuilder.SetCustomAttribute(builder1);
		    }
		}

	    public void BuildCustomAttributes(ILConversion conversion, ConvertedTypeWithMethods_I input, ConvertedBuiltMethod methodEntry)
	    {
		    var methodDefinition = (MethodDefinition)methodEntry.MethodReference;

			var builders = CreateCustomAttributeList(conversion, methodDefinition.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

			    methodEntry.MethodBuilder.SetCustomAttribute(builder1);
		    }

		    //builders = CreateCustomAttributeList(conversion, methodDefinition.MethodReturnType.CustomAttributes);

		    //for (int i = 0; i < builders.Count; i++)
		    //{
			   // var builder1 = builders[i];

			    
		    //}
		}

	    public void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinitionWithProperties_I convertedType, ConvertedProperty entry)
	    {
			var propertyDefinition = entry.PropertyDefinition;

		    var builders = CreateCustomAttributeList(conversion, propertyDefinition.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

			    entry.Builder.SetCustomAttribute(builder1);
		    }
		}

	    public void BuildCustomAttributes(ILConversion conversion, ConvertedMethodParameter parameter)
	    {
			var parameterDefinition = parameter.ParameterDefinition;

		    var builders = CreateCustomAttributeList(conversion, parameterDefinition.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

			    parameter.Builder.SetCustomAttribute(builder1);
		    }
		}

	    public void BuildCustomAttributes(ILConversion conversion, ParameterBuilder returnParameter,
		    MethodReturnType methodReturnType)
	    {
		    var builders = CreateCustomAttributeList(conversion, methodReturnType.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

			    returnParameter.SetCustomAttribute(builder1);
		    }
		}


	    public void BuildCustomAttributes(ILConversion conversion, ConvertedTypeDefinition_I converted)
	    {
		    var typeDefinition = (TypeDefinition)converted.SourceTypeReference;

		    var builders = CreateCustomAttributeList(conversion, typeDefinition.CustomAttributes);

		    for (int i = 0; i < builders.Count; i++)
		    {
			    var builder1 = builders[i];

				converted.TypeBuilder.SetCustomAttribute(builder1);
		    }
		}

	    private List<CustomAttributeBuilder> CreateCustomAttributeList(ILConversion conversion, Collection<CustomAttribute> cecilCustomAttributes)
	    {
		    List<CustomAttributeBuilder> builders = new List<CustomAttributeBuilder>();


		    for (int i = 0; i < cecilCustomAttributes.Count; i++)
		    {
			    var cecilCustomAttribute = cecilCustomAttributes[i];

			    var boundAttribute = Execution.Types.Ensuring.EnsureBound(conversion.Model, cecilCustomAttribute.AttributeType);

			    // What constructor do I get?



			    var constructor = Constructors.Getting.GetConstructor(conversion, (BoundTypeDefinitionWithConstructorsMask_I) boundAttribute, cecilCustomAttribute.Constructor);

			    if (!(constructor is BoundConstructorDefinitionMask_I boundConstructor))
			    {
				    throw new Exception("Not a bound constructor.");
			    }

			    // Where do I get the constructor args?

			    object[] constructorArgs = new object[0];

			    if (cecilCustomAttribute.HasConstructorArguments)
			    {
				    // bool, byte, char, double, float, int, long, sbyte, short, string, uint, ulong, ushort.
				    // object.
				    // System.Type.
				    // An enum type, provided it has public accessibility and the types in which it is nested (if any) also have public accessibility (Attribute specification).
				    // Array
				    constructorArgs = new object[cecilCustomAttribute.ConstructorArguments.Count];

				    for (int j = 0; j < cecilCustomAttribute.ConstructorArguments.Count; j++)
				    {
					    var constructorArgument = cecilCustomAttribute.ConstructorArguments[j];

					    constructorArgs[j] = GetCustomAttributeArgumentValue(conversion, constructorArgument);
				    }
			    }

			    PropertyInfo[] propertyInfos = new PropertyInfo[0];

			    object[] propertyValues = new object[0];

			    if (cecilCustomAttribute.HasProperties)
			    {
				    propertyInfos = new PropertyInfo[cecilCustomAttribute.Properties.Count];

				    propertyValues = new object[cecilCustomAttribute.Properties.Count];

				    for (int j = 0; j < cecilCustomAttribute.Properties.Count; j++)
				    {
					    var namedArgument = cecilCustomAttribute.Properties[j];

					    var boundProperty = Properties.GetBoundProperty(boundAttribute, namedArgument.Name);

					    propertyInfos[j] = boundProperty.UnderlyingPropertyInfo;

					    propertyValues[j] = GetCustomAttributeArgumentValue(conversion, namedArgument.Argument);
				    }
			    }

			    FieldInfo[] fieldInfos = new FieldInfo[0];

			    object[] fieldValues = new object[0];

			    if (cecilCustomAttribute.HasFields)
			    {
				    fieldInfos = new FieldInfo[cecilCustomAttribute.Fields.Count];

				    fieldValues = new object[cecilCustomAttribute.Fields.Count];

				    for (int j = 0; j < cecilCustomAttribute.Fields.Count; j++)
				    {
					    var namedArgument = cecilCustomAttribute.Fields[j];

					    var boundField = Fields.Getting.GetBoundField(boundAttribute, namedArgument.Name);

					    fieldInfos[j] = boundField.UnderlyingField;

					    fieldValues[j] = GetCustomAttributeArgumentValue(conversion, namedArgument.Argument);
				    }
			    }

			    CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(boundConstructor.UnderlyingConstructor,
				    constructorArgs, propertyInfos, propertyValues, fieldInfos, fieldValues);

			    builders.Add(customAttributeBuilder);
		    }
		    return builders;
	    }

	    private object GetCustomAttributeArgumentValue(ILConversion conversion, CustomAttributeArgument constructorArgument)
	    {
		    var arrayOfArguments = constructorArgument.Value as CustomAttributeArgument[];

		    if (constructorArgument.Value is TypeReference typeReference)
		    {
			    return Execution.Types.Ensuring.EnsureToType(conversion.Model, typeReference);
		    }
		    if (arrayOfArguments != null)
		    {
			    object[] array = new object[arrayOfArguments.Length];

			    for (int i = 0; i < array.Length; i++)
			    {
				    array[i] = GetCustomAttributeArgumentValue(conversion, arrayOfArguments[i]);
			    }

			    return array;
		    }
		    else
		    {
			    return constructorArgument.Value;
		    }
	    }

	}
}
