using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members
{
    public static class TypeExts
    {
        public static bool HasTypeArguments(this GenericTypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.HasTypeArguments(type);
        }

        public static bool HasTypeParameters(this GenericTypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.HasTypeParameters(type);
        }

        

        public static bool IsArrayType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsArrayType(type);
        }

	    public static bool IsByRef(this TypeMask_I type)
	    {
		    return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsByRef(type);
	    }

		public static bool IsClassType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsClassType(type);
        }

        

        public static bool IsDefinition(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsDefinition(type);
        }

        public static bool IsDelegateType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsDelegateType(type);
        }

        public static bool IsEnumType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsEnumType(type);
        }

        public static bool IsGeneric(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsGeneric(type);
        }

        public static bool IsInterface(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsInterface(type);
        }

        public static bool IsNestedType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsNestedType(type);
        }

        public static bool IsNullableValueType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsNullableValueType(type);
        }

        

        public static bool IsReference(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsReference(type);
        }

        public static bool IsReferenceType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsReferenceType(type);
        }

        public static bool IsSimpleClType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsSimpleClType(type);
        }

        public static bool IsStruct(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsStruct(type);
        }


        public static bool IsTypeParameter(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsTypeParameter(type);
        }

        public static bool IsValueType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.IsValueType(type);
        }

        public static string ResolutionName(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.ResolutionName(type);
        }

        public static bool SupportsInterfaceTypeList(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.SupportsInterfaceTypeList(type);
        }

        public static bool SupportsBaseType(this TypeMask_I type)
        {
            return XPal.Api.Runtimic.Infrastructure.Metadata.Members.Typal.SupportsBaseType(type);
        }
    }
}
