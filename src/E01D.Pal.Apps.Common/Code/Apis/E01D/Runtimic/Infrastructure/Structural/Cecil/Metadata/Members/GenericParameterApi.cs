using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public class GenericParameterApi<TContainer> : RuntimeApiNode<TContainer>, GenericParameterApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public System.Reflection.GenericParameterAttributes GetGenericParameterAttributes(TypeParameterConstraintKind attributes)
		{
			var x = System.Reflection.GenericParameterAttributes.None;

			if ((attributes & TypeParameterConstraintKind.DefaultConstructorConstraint) == TypeParameterConstraintKind.DefaultConstructorConstraint)
			{
				x |= System.Reflection.GenericParameterAttributes.DefaultConstructorConstraint;
			}
			if ((attributes & TypeParameterConstraintKind.NotNullableValueTypeConstraint) == TypeParameterConstraintKind.NotNullableValueTypeConstraint)
			{
				x |= System.Reflection.GenericParameterAttributes.NotNullableValueTypeConstraint;
			}
			if ((attributes & TypeParameterConstraintKind.ReferenceTypeConstraint) == TypeParameterConstraintKind.ReferenceTypeConstraint)
			{
				x |= System.Reflection.GenericParameterAttributes.ReferenceTypeConstraint;
			}
			if ((attributes & TypeParameterConstraintKind.Contravariant) == TypeParameterConstraintKind.Contravariant)
			{
				x |= System.Reflection.GenericParameterAttributes.Contravariant;
			}
			if ((attributes & TypeParameterConstraintKind.Covariant) == TypeParameterConstraintKind.Covariant)
			{
				x |= System.Reflection.GenericParameterAttributes.Covariant;
			}

			return x;
		}

		public TypeParameterConstraintKind GetTypeParameterAttributes(Mono.Cecil.GenericParameter constraint)
		{
			var attributes = TypeParameterConstraintKind.None;

			if ((constraint.Attributes & GenericParameterAttributes.Covariant) == GenericParameterAttributes.Covariant)
			{
				attributes |= TypeParameterConstraintKind.Covariant;
			}

			if ((constraint.Attributes & GenericParameterAttributes.Contravariant) == GenericParameterAttributes.Contravariant)
			{
				attributes |= TypeParameterConstraintKind.Contravariant;
			}

			if ((constraint.Attributes & GenericParameterAttributes.ReferenceTypeConstraint) == GenericParameterAttributes.ReferenceTypeConstraint)
			{
				attributes |= TypeParameterConstraintKind.ReferenceTypeConstraint;
			}
			if ((constraint.Attributes & GenericParameterAttributes.DefaultConstructorConstraint) == GenericParameterAttributes.DefaultConstructorConstraint)
			{
				attributes |= TypeParameterConstraintKind.DefaultConstructorConstraint;
			}
			if ((constraint.Attributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == GenericParameterAttributes.NotNullableValueTypeConstraint)
			{
				attributes |= TypeParameterConstraintKind.NotNullableValueTypeConstraint;
			}


			return attributes;
		}
	}
}
