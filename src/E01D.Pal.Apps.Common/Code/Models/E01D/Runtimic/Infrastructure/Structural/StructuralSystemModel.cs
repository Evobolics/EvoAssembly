namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural
{
	/// <summary>
	/// Represents the structrual system that is responible for providing structural models to the runtimic type system.
	/// </summary>
	public class StructuralSystemModel
	{
		public StructuralSystemModelAssemblies Assemblies { get; set; } = new StructuralSystemModelAssemblies();

		public StructuralSystemModelModules Modules { get; set; } = new StructuralSystemModelModules();

		public StructuralSystemModelTypes Types { get; set; } = new StructuralSystemModelTypes();
	}
}
