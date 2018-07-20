using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedModuleNode
	{
		public UnifiedModuleNode()
		{
				
		}

		public UnifiedAssemblyNode AssemblyNode { get; set; }

		public ModuleDefinition ModuleDefinition { get; set; }

		public SemanticModuleMask_I Semantic { get; set; }

		public string Name { get; set; }
		public UnifiedModuleNode Next { get; set; }
		
	}
}
