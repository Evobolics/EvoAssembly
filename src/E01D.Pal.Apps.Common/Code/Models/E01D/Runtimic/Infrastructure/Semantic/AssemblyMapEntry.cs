using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic
{
	public class AssemblyMapEntry
	{
		public string AssemblyQualifiedName { get; set; }

		public AssemblyDefinition Input { get; set; }

		public SemanticAssemblyMask_I Output { get; set; }
	}
}
