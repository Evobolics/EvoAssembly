using System.Collections.Generic;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural
{
	public interface StructuralModelAssembliesMask_I
	{
		Dictionary<string, AssemblyDefinition> Definitions { get;  }
	}
}
