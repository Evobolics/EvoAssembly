using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields
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

            var fields = typeDefinition.Fields;

            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];

                EnsureTypes(conversion, field, typeReference);
            }
        }

        public void EnsureTypes(ILConversion conversion, FieldDefinition field, TypeReference genericArgumentSource)
        {
            var fieldTypeReference = field.FieldType;

            // If generic, go ahead and skip.  It will get resolved.
            if (fieldTypeReference.IsGenericParameter) return;

            var resolvedReturnTypeReference = Cecil.ResolveForTypeScan(genericArgumentSource, fieldTypeReference);

            var returnTypeDefinition = Models.Types.ResolveToTypeDefinition(conversion.Model, resolvedReturnTypeReference);

	        Types.Ensuring.Ensure(conversion, returnTypeDefinition, null);
        }
    }
}
