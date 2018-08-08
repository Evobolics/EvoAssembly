using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural
{
	public class StructuralApi<TContainer> : RuntimeApiNode<TContainer>, StructuralApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		
		public CecilApi_I<TContainer> Cecil { get; set; }

		CecilApiMask_I StructuralApiMask_I.Cecil => Cecil;

		public MetadataApi_I<TContainer> Metadata { get; set; }

		MetadataApiMask_I StructuralApiMask_I.Metadata => Metadata;

        public NamingApi_I<TContainer> Naming { get; set; }

		NamingApiMask_I StructuralApiMask_I.Naming => Naming;

		public Metadata.Members.Types.TypeApiMask_I Types => Metadata.Members.Types;

	}
}
