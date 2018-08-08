using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Events
{
    public class TypeScanningApi<TContainer> : ConversionApiNode<TContainer>, TypeScanningApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void EnsureTypes(ILConversion conversion, SemanticTypeMask_I boundTypeMask)
        {
            if (!boundTypeMask.IsDefinition())
            {
                return;
            }

            var typeDefinitionMask = (SemanticTypeDefinitionMask_I)boundTypeMask;

            var typeReference = typeDefinitionMask.SourceTypeReference;

            var typeDefinition = Cecil.GetFundamentalTypeDefinition(typeReference);

            var events = typeDefinition.Events;

            for (int i = 0; i < events.Count; i++)
            {
                var event1 = events[i];

                EnsureTypes(conversion, event1, typeReference);
            }
        }

        private void EnsureTypes(ILConversion conversion, EventDefinition propertyDefinition, TypeReference genericArgumentSource)
        {
            var eventTypeReference = propertyDefinition.EventType;

            // If generic, go ahead and skip.  It will get resolved.
            if (eventTypeReference.IsGenericParameter) return;

            var resolvedEventTypeReference = Cecil.ResolveAnyTypeArguments(genericArgumentSource, propertyDefinition.EventType);

            var eventTypeDefinition = Models.Types.ResolveToTypeDefinition(conversion.RuntimicSystem, resolvedEventTypeReference);

	        Execution.Types.Ensuring.Ensure(conversion, eventTypeDefinition, null, null);
        }
    }
}
