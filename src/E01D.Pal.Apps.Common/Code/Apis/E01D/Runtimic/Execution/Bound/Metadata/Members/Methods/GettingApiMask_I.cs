using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Methods
{
    public interface GettingApiMask_I
    {
	    SemanticMethodMask_I FindMethodByDefinition(InfrastructureRuntimicModelMask_I model,
		    BoundTypeDefinitionWithMethodsMask_I boundTypeWithMethods, MethodDefinition methodDefinition);

    }
}
