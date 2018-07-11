namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public class SemanticModel: SemanticModelMask_I
	{
		public SemanticModelAssemblies Assemblies { get; set; }

		public SemanticModelModules Modules { get; set; }


		public SemanticModelTypes Types { get; set; }

		SemanticModelAssembliesMask_I SemanticModelMask_I.Assemblies => Assemblies;

		SemanticModelModulesMask_I SemanticModelMask_I.Modules => Modules;

		

		SemanticModelTypesMask_I SemanticModelMask_I.Types => Types;

	}
}
