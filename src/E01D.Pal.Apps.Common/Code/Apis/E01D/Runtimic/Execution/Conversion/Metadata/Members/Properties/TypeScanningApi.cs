using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Properties
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

            var properties = typeDefinition.Properties;

            for (int i = 0; i < properties.Count; i++)
            {
                var property = properties[i];

                EnsureTypes(conversion, property, typeReference);
            }
        }

        private void EnsureTypes(ILConversion conversion, PropertyDefinition propertyDefinition, TypeReference genericArgumentSource)
        {
            var propertyTypeReference = propertyDefinition.PropertyType;

            // If generic, go ahead and skip.  It will get resolved.
            if (propertyTypeReference.IsGenericParameter) return;

            var resolvedPropertyTypeReference = Cecil.ResolveAnyTypeArguments(genericArgumentSource, propertyTypeReference);

            var propertyTypeDefinition = Models.Types.ResolveToTypeDefinition(conversion.RuntimicSystem, resolvedPropertyTypeReference);

	        //Execution.Types.Ensuring.Ensure(conversion.Model, propertyTypeDefinition, null, null);

            throw new System.Exception("Fix");
        }
    }
}
