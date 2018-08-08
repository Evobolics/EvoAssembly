using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface TypeApiMask_I
	{
		UnifiedTypeNode Extend(RuntimicSystemModel model, UnifiedAssemblyNode assemblyNode,
			UnifiedModuleNode moduleNode, TypeReference typeReference);


		UnifiedTypeNode Get(RuntimicSystemModel model, string fullName);

		void Update(RuntimicSystemModel semanticModel, SemanticTypeDefinitionMask_I semanticType);

		void ExtendWithCrossReference(RuntimicSystemModel model, SemanticTypeDefinitionMask_I semanticType,
			string assemblyQualifiedNameCrossReferenceKey);

		bool IsAssociatedWithASecondaryNode(TypeReference contextTypeReference);
		UnifiedTypeNode Ensure(RuntimicSystemModel boundModel, TypeReference contextTypeReference);
	}
}
