using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Constructors;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Parameters;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public class MemberApi<TContainer> : RuntimeApiNode<TContainer>, MemberApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public ConstructorApi_I<TContainer> Constructors { get; set; }

		ConstructorApiMask_I MemberApiMask_I.Constructors => Constructors;

		public FieldApi_I<TContainer> Fields { get; set; }

		FieldApiMask_I MemberApiMask_I.Fields => Fields;

		public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

		GenericParameterApiMask_I MemberApiMask_I.GenericParameters => GenericParameters;

		public MethodApi_I<TContainer> Methods { get; set; }

		MethodApiMask_I MemberApiMask_I.Methods => Methods;

		public ParameterApi_I<TContainer> Parameters { get; set; }

		ParameterApiMask_I MemberApiMask_I.Parameters => Parameters;

		public TypeApi_I<TContainer> Types { get; set; }

		TypeApiMask_I MemberApiMask_I.Types => Types;
	}
}
