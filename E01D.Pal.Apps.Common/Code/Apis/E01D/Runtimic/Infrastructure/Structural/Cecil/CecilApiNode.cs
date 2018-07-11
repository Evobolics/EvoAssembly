using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Parameters;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil
{
	public class CecilApiNode<TContainer>: RuntimeApiNode<TContainer>
		where TContainer:RuntimicContainer_I<TContainer>
	{
		public ConstructorApiMask_I Constructors => Infrastructure.Structural.Cecil.Metadata.Members.Constructors;

		public  MethodApiMask_I Methods => Infrastructure.Structural.Cecil.Metadata.Members.Methods;

		public ParameterApiMask_I Parameters => Infrastructure.Structural.Cecil.Metadata.Members.Parameters;

		public TypeApiMask_I Types => Infrastructure.Structural.Cecil.Metadata.Members.Types;

	}
}
