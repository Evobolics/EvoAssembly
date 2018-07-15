using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
	public class UnifiedApi<TContainer> : UnifiedApiNode<TContainer>, UnifiedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public AssemblyApi_I<TContainer> Assemblies { get; set; }

		AssemblyApiMask_I UnifiedApiMask_I.Assemblies => Assemblies;

		public ModuleApi_I<TContainer> Modules { get; set; }

		ModuleApiMask_I UnifiedApiMask_I.Modules => Modules;

		public TypeApi_I<TContainer> Types { get; set; }

		TypeApiMask_I UnifiedApiMask_I.Types => Types;
	}
}
