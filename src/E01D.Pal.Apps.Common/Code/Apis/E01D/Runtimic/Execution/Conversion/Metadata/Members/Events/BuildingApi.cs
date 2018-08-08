using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
    where TContainer : RuntimicContainer_I<TContainer>
    {
        public void BuildEvents(ILConversion conversion, ConvertedTypeDefinition_I input)
        {
            // Done on purpose to find errors
            var typeDefinition = (TypeDefinition)input.SourceTypeReference;

            if (!typeDefinition.HasEvents) return;

	        if (!(input is ConvertedTypeDefinitionWithEvents_I inputWithEvents))
	        {
		        throw new System.Exception("Expected a type that can store properties.");
	        }

			for (int i = 0; i < typeDefinition.Events.Count; i++)
            {
                var event1 = typeDefinition.Events[i];

                BuildEvent(conversion, inputWithEvents, event1);
            }
        }

        private void BuildEvent(ILConversion conversion, ConvertedTypeDefinitionWithEvents_I converted, EventDefinition eventDefinition)
        {
			var eventAttributes = GetEventAttributes(eventDefinition);

	        var eventType = Execution.Types.Ensuring.EnsureToType(conversion, eventDefinition.EventType);

	        var builder = converted.TypeBuilder.DefineEvent(eventDefinition.Name, eventAttributes, eventType);

	        var entry = new ConvertedEvent()
	        {
				Name = eventDefinition.Name,
		        Builder = builder,
				EventDefinition = eventDefinition
			};

			if (!converted.Events.ByName.TryGetValue(entry.Name, out List<SemanticEventMask_I> propertyList))
	        {
		        propertyList = new List<SemanticEventMask_I>();

		        converted.Events.ByName.Add(entry.Name, propertyList);
	        }

	        propertyList.Add(entry);

			if (eventDefinition.InvokeMethod != null)
	        {
		        var invokeMethod = Methods.Getting.GetMethod(converted, eventDefinition.InvokeMethod);

		        if (invokeMethod?.UnderlyingMethod == null)
		        {
			        throw new System.Exception("Expected an invoke method");
		        }

		        builder.SetRaiseMethod((MethodBuilder)invokeMethod?.UnderlyingMethod);
	        }

	        if (eventDefinition.AddMethod != null)
	        {
		        var addMethod = Methods.Getting.GetMethod(converted, eventDefinition.AddMethod);

		        if (addMethod?.UnderlyingMethod == null)
		        {
			        throw new System.Exception("Expected an add method");
		        }

		        builder.SetAddOnMethod((MethodBuilder)addMethod?.UnderlyingMethod);
	        }



	        if (eventDefinition.RemoveMethod != null)
	        {
		        var removeMethod = Methods.Getting.GetMethod(converted, eventDefinition.RemoveMethod);

		        if (removeMethod?.UnderlyingMethod == null)
		        {
			        throw new System.Exception("Expected a remove method");
		        }



		        builder.SetRemoveOnMethod((MethodBuilder)removeMethod?.UnderlyingMethod);
	        }

	        CustomAttributes.BuildCustomAttributes(conversion, converted, entry);
		}

	    private System.Reflection.EventAttributes GetEventAttributes(EventDefinition propertyDefinition)
	    {
		    System.Reflection.EventAttributes attributes = System.Reflection.EventAttributes.None;

		    var cecilAttributes = propertyDefinition.Attributes;

		    if ((cecilAttributes & EventAttributes.RTSpecialName) == EventAttributes.RTSpecialName)
		    {
			    attributes |= System.Reflection.EventAttributes.RTSpecialName;
		    }
		    if ((cecilAttributes & EventAttributes.SpecialName) == EventAttributes.SpecialName)
		    {
			    attributes |= System.Reflection.EventAttributes.SpecialName;
		    }

		    return attributes;
	    }
	}
}
