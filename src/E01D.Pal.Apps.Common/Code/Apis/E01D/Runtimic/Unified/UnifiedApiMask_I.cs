namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public interface UnifiedApiMask_I
	{

		ArrayApiMask_I Arrays { get; }

		AssemblyApiMask_I Assemblies { get; }

		

		ModuleApiMask_I Modules { get; }

		TypeApiMask_I Types { get; }
	}
}
