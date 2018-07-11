using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural
{
	public interface StructuralModelMask_I
	{
		StructuralModelAssembliesMask_I Assemblies { get; }

		StructuralModelTypesMask_I Types { get; }

		List<System.IO.Stream> Streams { get; }
	}
}
