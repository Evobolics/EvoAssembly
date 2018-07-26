using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public class MetadataApi<TContainer> : SemanticApiNode<TContainer>, MetadataApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public AssemblyApi_I<TContainer> Assemblies { get; set; }

		AssemblyApiMask_I MetadataApiMask_I.Assemblies => Assemblies;

		public InstructionApi_I<TContainer> Instructions { get; set; }

		InstructionApiMask_I MetadataApiMask_I.Instructions => Instructions;

		public MemberApi_I<TContainer> Members { get; set; }

		MemberApiMask_I MetadataApiMask_I.Members => Members;

		public ModuleApi_I<TContainer> Modules { get; set; }

		ModuleApiMask_I MetadataApiMask_I.Modules => Modules;
	}
}
