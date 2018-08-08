namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedMetadataModel: UnifiedMetadataModelMask_I
	{
		public UnifiedModelAssembliesMask_I Assemblies { get; set; }
		
		public UnifiedModelModulesMask_I Modules { get; set; }
		public UnifiedModelTypesMask_I Types { get; set; }
	}
}
