using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods.Getting;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public interface MethodApiMask_I
    {

	    BuildingApiMask_I Building { get; }

	    GettingApiMask_I Getting { get; }

		SemanticMethodMask_I FindMethodByDefinition(InfrastructureRuntimicModelMask_I model, BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods, MethodDefinition methodDefinition);
    }
}
