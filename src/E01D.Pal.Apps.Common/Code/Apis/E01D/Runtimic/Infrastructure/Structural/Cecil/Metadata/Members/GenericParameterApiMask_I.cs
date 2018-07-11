using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public interface GenericParameterApiMask_I
	{
		System.Reflection.GenericParameterAttributes GetGenericParameterAttributes(TypeParameterConstraintKind attributes);

		TypeParameterConstraintKind GetTypeParameterAttributes(Mono.Cecil.GenericParameter constraint);
	}
}
