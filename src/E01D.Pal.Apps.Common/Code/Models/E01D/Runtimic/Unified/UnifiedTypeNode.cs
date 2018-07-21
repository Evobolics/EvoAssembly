using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
    public class UnifiedTypeNode
    {

		public string ResolutionName { get; set; }
		public UnifiedAssemblyNode AssemblyNode { get; set; }

        public UnifiedModuleNode ModuleNode { get; set; }

        public UnifiedTypeNode BlueprintNode { get; set; }

	    public TypeReference SourceTypeReference { get; set; }

		public SemanticTypeDefinitionMask_I SemanticType { get; set; }

	    public SemanticTypeDefinitionMask_I PointerType { get; set; }

	    public SemanticTypeDefinitionMask_I ByReferenceType { get; set; }
		public UnifiedTypeNode Next { get; set; }

        


    }
}
