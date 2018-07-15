namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedModel: UnifiedModelMask_I
	{
		public UnifiedModelAssemblies Assemblies { get; set; } = new UnifiedModelAssemblies();

		public UnifiedModelModules Modules { get; set; } = new UnifiedModelModules();

		public UnifiedModelTypes Types { get; set; } = new UnifiedModelTypes();

		UnifiedModelAssembliesMask_I UnifiedModelMask_I.Assemblies => Assemblies;

		UnifiedModelModulesMask_I UnifiedModelMask_I.Modules => Modules;

		UnifiedModelTypesMask_I UnifiedModelMask_I.Types => Types;
	}
}
