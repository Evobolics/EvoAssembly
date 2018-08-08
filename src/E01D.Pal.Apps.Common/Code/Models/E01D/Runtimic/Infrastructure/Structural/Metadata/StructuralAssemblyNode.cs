using System;
using System.Collections.Generic;
using System.IO;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata
{
	public class StructuralAssemblyNode
	{
		public StructuralAssemblyNode()
		{
				
		}

		public AssemblyDefinition CecilAssemblyDefinition { get; set; }

		/// <summary>
		/// Gets or sets the unified node associated with this structural node.
		/// </summary>
		public UnifiedAssemblyNode UnifiedNode { get; set; }

		public long Id { get; set; }

		public long MetadataId { get; set; }

		public StructuralAssemblySourceKind SourceKind { get; set; }
		public string Location { get; set; }
		public string FullName { get; set; }
		public MemoryStream Stream { get; set; }
		public Dictionary<Guid, StructuralModuleNode> Modules { get; set; } = new Dictionary<Guid, StructuralModuleNode>();

		public Dictionary<string, StructuralTypeNode> Types { get; set; } = new Dictionary<string, StructuralTypeNode>();
	}
}
