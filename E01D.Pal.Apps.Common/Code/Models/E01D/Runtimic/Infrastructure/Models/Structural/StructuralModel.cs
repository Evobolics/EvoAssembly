using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Structural
{
	public class StructuralModel: StructuralModelMask_I
	{
		public StructuralModelAssemblies Assemblies { get; set; } = new StructuralModelAssemblies();

		StructuralModelAssembliesMask_I StructuralModelMask_I.Assemblies => Assemblies;

		public StructuralModelTypes Types { get; set; } = new StructuralModelTypes();

		StructuralModelTypesMask_I StructuralModelMask_I.Types => Types;

		public List<System.IO.Stream> Streams { get; set; } = new List<System.IO.Stream>();
	}
}
