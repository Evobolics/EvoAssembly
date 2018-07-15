using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public class FieldApi<TContainer> : SemanticApiNode<TContainer>, FieldApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        public SemanticFieldMask_I Get(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I declaringType, string fieldName)
        {
            if (!(declaringType is SemanticTypeDefinitionWithFieldsMask_I typeWithFields))
            {
                throw new Exception("Trying to build a field on a type that does not support fields.");
            }

            if (typeWithFields.Fields.ByName.TryGetValue(fieldName, out SemanticFieldMask_I field))
            {
                return field;
            }

            return null;
        }

        


    }
}
