using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
	public interface CollectionApiMask_I
	{
		void Add(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType);

		

		SemanticTypeMask_I Get(InfrastructureModelMask_I semanticModel, TypeReference input);

		SemanticTypeDefinitionMask_I Get(InfrastructureModelMask_I semanticModel, string resolutionName);

		SemanticTypeMask_I GetOrThrow(InfrastructureModelMask_I model, TypeDefinition typeDefinition);

		SemanticTypeMask_I GetOrThrow(InfrastructureModelMask_I semanticModel, string resolutionName);

		



		



		bool TryGet(InfrastructureModelMask_I model, string resolutionName, out SemanticTypeDefinitionMask_I typeEntry);

		bool TryGet(InfrastructureModelMask_I model, TypeReference input, out SemanticTypeDefinitionMask_I typeEntry);
		void AddCrossReference(InfrastructureModelMask_I conversionModel, SemanticTypeDefinitionMask_I converted, string underlyingTypeFullName);
	}
}
