namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface UnifiedApiMask_I
	{
		AssemblyApiMask_I Assemblies { get; }
		
		ModuleApiMask_I Modules { get; }

		TypeApiMask_I Types { get; }
	}
}
