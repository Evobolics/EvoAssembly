using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields
{
    public interface FieldApiMask_I
    {
		Fields.Building.BuildingApiMask_I Building { get; }
		SemanticFieldMask_I Get(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I declaringType, string fieldName);

        FieldInfo GetFieldInfo(InfrastructureRuntimicModelMask_I conversionModel, SemanticTypeDefinitionMask_I declaringType, string fieldName);
    }
}
