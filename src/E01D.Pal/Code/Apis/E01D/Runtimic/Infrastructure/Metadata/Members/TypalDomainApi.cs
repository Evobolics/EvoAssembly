using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Metadata.Members
{
    public class TypalDomainApi: TypalDomainApi_I
    {
        public bool HasTypeArguments(GenericTypeMask_I type)
        {
            return Is(type, GenericTypeKind.HasTypeArguments);
        }

        public bool HasTypeParameters(GenericTypeMask_I type)
        {
            return Is(type, GenericTypeKind.HasTypeParameters);
        }

        public bool Is(TypeMask_I type, TypeKind kind)
        {
            return (type.TypeKind & kind) == kind;
        }

        public bool Is(GenericTypeMask_I type, GenericTypeKind kind)
        {
            return (type.GenericKind & kind) == kind;
        }

        public bool IsArrayType(TypeMask_I type)
        {
            return Is(type, TypeKind.Array);
        }

	    public bool IsByRef(TypeMask_I type)
	    {
		    return Is(type, TypeKind.ByRef);
	    }

		public bool IsClassType(TypeMask_I type)
        {
            return Is(type, TypeKind.Class);
        }

        public bool IsClosedType(GenericTypeMask_I type)
        {
            return Is(type, GenericTypeKind.Closed);
        }

        public bool IsDefinition(TypeMask_I type)
        {
            return Is(type, TypeKind.Definition);
        }

        public bool IsDelegateType(TypeMask_I type)
        {
            return Is(type, TypeKind.Delegate);
        }

        public bool IsEnumType(TypeMask_I type)
        {
            return Is(type, TypeKind.Enum);
        }

        public bool IsGeneric(TypeMask_I type)
        {
            return Is(type, TypeKind.Generic);
        }

        public bool IsInterface(TypeMask_I type)
        {
            return Is(type, TypeKind.Interface);
        }

        public bool IsNullableValueType(TypeMask_I type)
        {
            return Is(type, TypeKind.NullableValueType);
        }

        public bool IsOpenType(GenericTypeMask_I type)
        {
            return Is(type, GenericTypeKind.Open);
        }

        

        public bool IsReference(TypeMask_I type)
        {
            return Is(type, TypeKind.Reference);
        }

        public bool IsReferenceType(TypeMask_I type)
        {
            return Is(type, TypeKind.ReferenceType);
        }

        public bool IsSimpleClType(TypeMask_I type)
        {
            return Is(type, TypeKind.Simple | TypeKind.CommonLanguage);
        }

        public bool IsSimpleSolidityType(TypeMask_I type)
        {
            return Is(type, TypeKind.Simple | TypeKind.Solidity);
        }

        public bool IsStruct(TypeMask_I type)
        {
            return Is(type, TypeKind.Struct);
        }

        public bool IsTypeParameter(TypeMask_I type)
        {
            return Is(type, TypeKind.TypeParameter);
        }

        public bool IsValueType(TypeMask_I type)
        {
            return Is(type, TypeKind.ValueType);
        }

        public string ResolutionName(TypeMask_I type)
        {
            var result = type.AssemblyQualifiedName;

	        if (result == null)
	        {
		        throw new System.Exception("Resolution name cannot be null.");
	        }

	        return result;
        }

        /// <summary>
        /// Gets if the value type is a single dimensional array
        /// that is implemented as vector.
        /// </summary>
        public bool IsVector(TypeMask_I type)
        {
            return Is(type, TypeKind.Vector);
        }

        public bool SupportsInterfaceTypeList(TypeMask_I type)
        {
            return Is(type, TypeKind.SupportsInterfaceTypeList);
        }

        public bool SupportsBaseType(TypeMask_I type)
        {
            return Is(type, TypeKind.SupportsBaseType);
        }

        public bool IsNestedType(TypeMask_I type)
        {
            return Is(type, TypeKind.Nested);
        }
    }
}
