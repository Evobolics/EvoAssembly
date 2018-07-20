using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic
{
	public class AssemblyMap
	{
		public Dictionary<string, AssemblyMapEntry> Mappings { get; set; }

		// in the case of bound asemblies, they are mapped one to one.  Every assembly that comes in, is mapped to an equivelent assembly in the model.
		public Dictionary<string, AssemblyDefinition> Inputs { get; set; }

		public Dictionary<string, SemanticAssemblyMask_I> Outputs { get; set; }
	}
}
