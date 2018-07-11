namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public interface SemanticModelMask_I
	{
		SemanticModelAssembliesMask_I Assemblies { get; }

		SemanticModelModulesMask_I Modules { get; }



		SemanticModelTypesMask_I Types { get; }
	}
}
