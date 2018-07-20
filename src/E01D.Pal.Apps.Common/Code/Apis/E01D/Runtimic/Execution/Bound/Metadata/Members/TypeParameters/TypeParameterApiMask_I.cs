using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeParameters
{
    public interface TypeParameterApiMask_I
    {
	    BuildingApiMask_I Building { get; }

	    void Add(InfrastructureRuntimicModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions,
		    SemanticGenericParameterTypeDefinitionMask_I typeParameter);

	    void Create();

	    void Add(InfrastructureRuntimicModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions,
		    List<SemanticGenericParameterTypeDefinitionMask_I> inputList);

	    void Clear(ILConversion conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions);

	    SemanticGenericParameterTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, string name);

	    SemanticGenericParameterTypeDefinitionMask_I Get(InfrastructureRuntimicModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, int position);

	    string[] GetNames(InfrastructureRuntimicModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions);

	    SemanticGenericParameterTypeDefinitionMask_I GetOrThrow(InfrastructureRuntimicModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, string name);

	    SemanticGenericParameterTypeDefinitionMask_I GetOrThrow(InfrastructureRuntimicModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, int position);

	    BoundTypeDefinitionMask_I Resolve(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I declaringType,
		    GenericParameter parameter);

	    BoundTypeDefinitionMask_I Resolve(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I declaringType,
		    MethodDefinition methodDefinition, GenericParameter parameter);
    }
}
