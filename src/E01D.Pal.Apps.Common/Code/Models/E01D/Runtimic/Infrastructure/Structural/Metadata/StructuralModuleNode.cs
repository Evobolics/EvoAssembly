using System;
using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata
{
	public class StructuralModuleNode
	{
		public StructuralModuleNode()
		{
				
		}

		public ModuleDefinition CecilModuleDefinition { get; set; }

        public Dictionary<int, StructuralTypeTable> Tables { get; set; } =
			new Dictionary<int, StructuralTypeTable>();

		public Guid VersionId { get; set; }
		public StructuralAssemblyNode Assembly { get; set; }
	}
}
