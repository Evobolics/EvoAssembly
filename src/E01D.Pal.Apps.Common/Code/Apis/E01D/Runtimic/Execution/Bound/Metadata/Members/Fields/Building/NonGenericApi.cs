using System;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields.Building
{
	public class NonGenericApi<TContainer> : BoundApiNode<TContainer>, NonGenericApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildFields(RuntimicSystemModel semanticModel, BoundTypeDefinition_I input)
		{



			// Done on purpose to find errors
			var typeDefinition = (TypeDefinition)input.SourceTypeReference;

			if (!typeDefinition.HasFields) return;

			if (!(input is BoundTypeDefinitionWithFields_I typeWithFields))
			{
				throw new Exception("Trying to build a field on a type that does not support fields.");
			}

			System.Type type = input.UnderlyingType;

			for (int i = 0; i < typeDefinition.Fields.Count; i++)
			{
				var field = typeDefinition.Fields[i];

				var fieldInfo = type.GetField(field.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public
//					| BindingFlags.NonPublic
					);

				if (fieldInfo != null)
				{
					BuildField(semanticModel, typeWithFields, field, fieldInfo);
				}
			}
		}

		public void BuildField(RuntimicSystemModel semanticModel, BoundTypeDefinitionWithFields_I typeWithFields, FieldDefinition field, FieldInfo fieldInfo)
		{
			var fieldType = field.FieldType;

			// DotNet type is the elmeent type, not the elmenet type + modifier.
			if (field.FieldType.IsRequiredModifier)
			{
				RequiredModifierType modifierType = (RequiredModifierType) field.FieldType;

				fieldType = modifierType.ElementType;
			}

			Execution.Types.Ensuring.EnsureToType(semanticModel, fieldType, fieldInfo.FieldType, out BoundTypeDefinitionMask_I semanticFieldType);

			var convertedField = new BoundField()
			{
				FieldType = semanticFieldType,
				FieldDefinition = field,
				UnderlyingField = fieldInfo,
				Name = field.Name,
			};

			typeWithFields.Fields.ByName.Add(convertedField.Name, convertedField);
		}

		
	}
}
