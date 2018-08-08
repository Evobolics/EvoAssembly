using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class CreatingApi<TContainer> : CecilApiNode<TContainer>, CreatingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

//		public StructuralAssemblyNode Create(RuntimicSystemModel model, AssemblyDefinition assemblyDefinition)
//		{
//			string fullName = Assemblies.Naming.GetAssemblyName(assemblyDefinition);

//			return new StructuralAssemblyNode()
//			{
//				CecilAssemblyDefinition = assemblyDefinition,
//				Id = this.Identification.IssueId(model),
//				MetadataId = this.Identification.IssueId(model),
//				//Location = assembly.Location,
//				FullName = fullName,
////				SourceKind = StructuralAssemblySourceKind,
//				//Stream = new MemoryStream(bytes)
//			};
//		}

		
	}
}
