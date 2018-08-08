using System;
using Root.Code.Containers.E01D.Runtimic;
using System.Reflection;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling
{
    public class ModelFieldsApi<TContainer> : ConversionApiNode<TContainer>, ModelFieldsApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public FieldInfo ResolveFieldReference(ILConversion conversion, ConvertedTypeDefinitionMask_I accessingType, BoundTypeDefinitionMask_I declaringFieldReferenceType, FieldReference fieldReference)
        {
            // The problem we run into is that for generic types, we need the fully baked type and we do not have access to a builder
            // that is able to act as a type.  So I think we are going to have to bake the types.  It looks like we will have to figure out
            // what it takes to make that work.

            // OLD WAY
            

            var declaringTypeRef = fieldReference.DeclaringType;


            var declaringSematicType = Execution.Types.Ensuring.EnsureBound(conversion, declaringTypeRef);

            FieldInfo fieldInfo = null;

            if (declaringSematicType.IsConverted())
            {
                fieldInfo = Fields.GetFieldInfo(conversion, declaringSematicType, fieldReference.Name);
            }
            else
            {
                fieldInfo = Fields.GetFieldInfo(conversion, declaringSematicType.UnderlyingType, fieldReference);
                // Get field builder
            }

			// prevents returning a null reference to the IL builder.
			if (fieldInfo == null)
			{
				throw new Exception($"Expected to find field {fieldReference.Name} in type {declaringTypeRef.FullName}.");
			}
			
			return fieldInfo;
        }
    }
}
