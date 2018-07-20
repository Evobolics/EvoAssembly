using System;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields
{
	public class FieldApi<TContainer> : BoundApiNode<TContainer>, FieldApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    public Fields.Building.BuildingApi_I<TContainer> Building { get; set; }

	    Fields.Building.BuildingApiMask_I FieldApiMask_I.Building => Building;

		public SemanticFieldMask_I Get(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I declaringType, string fieldName)
        {
            return Semantic.Metadata.Members.Fields.Get(model, declaringType, fieldName);
        }

        public FieldInfo GetFieldInfo(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I declaringType, string fieldName)
        {
			// 1) First check the current type for the field.
            var result = Get(model, declaringType, fieldName);

			// 2.a) If not found, and is generic...
			if (result == null && declaringType is BoundGenericTypeDefinitionMask_I bound)
	        {
		        // 2.b) Check the blueprint for the field as it might take generic parameters.
				result = Get(model, bound.Blueprint, fieldName);
	        }

	        if (result == null) return null;

            if (!(result is BoundFieldDefinitionMask_I field))
            {
                throw new Exception("Cannot get a field info from a field hat is not convertible to a BoundFieldMask_I.");
            }

            return field.UnderlyingField;
        }

        public FieldInfo GetFieldInfo(InfrastructureRuntimicModelMask_I conversion, Type declaringType, FieldReference fieldReference)
        {
            return declaringType.GetField(fieldReference.Name);
        }
    }
}
 