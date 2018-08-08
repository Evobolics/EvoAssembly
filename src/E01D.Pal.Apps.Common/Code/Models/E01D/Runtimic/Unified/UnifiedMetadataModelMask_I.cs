namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public interface UnifiedMetadataModelMask_I
	{
		UnifiedModelAssembliesMask_I Assemblies { get; }

		UnifiedModelModulesMask_I Modules { get; }

		UnifiedModelTypesMask_I Types { get; }
	}
}
