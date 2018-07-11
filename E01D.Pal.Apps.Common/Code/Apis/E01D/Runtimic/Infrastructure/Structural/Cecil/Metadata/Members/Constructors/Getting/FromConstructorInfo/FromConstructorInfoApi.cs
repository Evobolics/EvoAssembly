using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors.Getting.FromConstructorInfo
{
	public class FromConstructorInfoApi<TContainer> : RuntimeApiNode<TContainer>, FromConstructorInfoApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public DefinitionApi_I<TContainer> Definitions { get; set; }


		DefinitionApiMask_I FromConstructorInfoApiMask_I.Definitions => Definitions;

		public ReferenceApi_I<TContainer> References { get; set; }


		ReferenceApiMask_I FromConstructorInfoApiMask_I.References => References;

		

		
	}
}
