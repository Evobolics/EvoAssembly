using System;
using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedAssemblyNode
	{
		public AssemblyDefinition SourceAssemblyDefinition { get; set; }

		

		public SemanticAssemblyMask_I Semantic { get; set; }

		public List<UnifiedModuleNode> ModuleNodes { get; set; } = new List<UnifiedModuleNode>();
		public string Name { get; set; }
		public UnifiedAssemblyNode Next { get; set; }
		public Guid Guid { get; set; }
	}
}
