using System.Collections.Generic;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural
{
	public class StructuralModelAssemblies: StructuralModelAssembliesMask_I
	{
		public Dictionary<string, AssemblyDefinition> Definitions { get; set; } = new Dictionary<string, AssemblyDefinition>();
	}
}
