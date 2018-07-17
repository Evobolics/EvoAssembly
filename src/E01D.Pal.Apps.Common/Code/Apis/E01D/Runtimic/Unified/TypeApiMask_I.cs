using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface TypeApiMask_I
	{
		UnifiedTypeNode Extend(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode assemblyNode,
			UnifiedModuleNode moduleNode, TypeReference typeReference);


		UnifiedTypeNode Get(UnifiedRuntimicModelMask_I model, string fullName);

		void Update(UnifiedRuntimicModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType);

		void ExtendWithCrossReference(UnifiedRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semanticType,
			string assemblyQualifiedNameCrossReferenceKey);
	}
}
