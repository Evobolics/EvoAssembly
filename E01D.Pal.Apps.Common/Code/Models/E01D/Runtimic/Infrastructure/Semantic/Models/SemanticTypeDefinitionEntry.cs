using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models
{
    public class SemanticTypeDefinitionEntry
    {

		public string ResolutionName { get; set; }
		public AssemblyDefinition SourceAssemblyDefinition { get; set; }

        public ModuleDefinition SourceModuleDefinition { get; set; }
        public TypeReference SourceTypeReference { get; set; }

        public TypeReference BlueprintTypeDefintion { get; set; }

        public SemanticTypeDefinitionMask_I SemanticType { get; set; }

	    

		/// <summary>
		/// Gets or sets the list of types that this type depends on being baked prior to its baking.
		/// </summary>


		
	}
}
