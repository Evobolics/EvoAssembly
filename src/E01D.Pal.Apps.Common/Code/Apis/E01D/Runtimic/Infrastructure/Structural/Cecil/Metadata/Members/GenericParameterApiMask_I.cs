using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public interface GenericParameterApiMask_I
	{
		System.Reflection.GenericParameterAttributes GetGenericParameterAttributes(TypeParameterConstraintKind attributes);

		TypeParameterConstraintKind GetTypeParameterAttributes(GenericParameter constraint);
	}
}
