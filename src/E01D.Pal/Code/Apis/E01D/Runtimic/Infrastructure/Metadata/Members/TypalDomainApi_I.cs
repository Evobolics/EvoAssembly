using Root.Code.Attributes.E01D;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata.Members
{
    [StaticApi]
    [PhenotypeMask]
    public interface TypalDomainApi_I
    {
        bool HasTypeArguments(GenericTypeMask_I type);

        bool HasTypeParameters(GenericTypeMask_I type);

        bool IsArrayType(TypeMask_I type);

	    bool IsByRef(TypeMask_I type);
		bool IsClassType(TypeMask_I type);
        bool IsClosedType(GenericTypeMask_I type);
        bool IsDefinition(TypeMask_I type);
        bool IsDelegateType(TypeMask_I type);
        bool IsEnumType(TypeMask_I type);
        bool IsGeneric(TypeMask_I type);
        bool IsInterface(TypeMask_I type);
        bool IsNullableValueType(TypeMask_I type);

        bool IsOpenType(GenericTypeMask_I type);
        bool IsReference(TypeMask_I type);
        bool IsReferenceType(TypeMask_I type);
        bool IsSimpleClType(TypeMask_I type);
        bool IsStruct(TypeMask_I type);
        bool IsTypeParameter(TypeMask_I type);
        bool IsValueType(TypeMask_I type);

        string ResolutionName(TypeMask_I type);
        bool SupportsInterfaceTypeList(TypeMask_I type);
        bool SupportsBaseType(TypeMask_I type);

        bool IsNestedType(TypeMask_I type);
    }
}
