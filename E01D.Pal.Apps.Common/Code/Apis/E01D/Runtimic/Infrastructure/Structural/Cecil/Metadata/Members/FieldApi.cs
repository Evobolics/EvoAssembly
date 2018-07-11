using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using FieldAttributes = System.Reflection.FieldAttributes;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members
{
	public class FieldApi<TContainer> : RuntimeApiNode<TContainer>, FieldApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public System.Reflection.FieldAttributes GetFieldAttributes(FieldDefinition fieldDefinition)
		{
			var attributes = fieldDefinition.Attributes;

			var newAttributes = System.Reflection.FieldAttributes.PrivateScope;

			if ((attributes & Mono.Cecil.FieldAttributes.Public) == Mono.Cecil.FieldAttributes.Public)
			{
				newAttributes |= System.Reflection.FieldAttributes.Public;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.Family) == Mono.Cecil.FieldAttributes.Family)
			{
				newAttributes |= System.Reflection.FieldAttributes.Family;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.FamANDAssem) == Mono.Cecil.FieldAttributes.FamANDAssem)
			{
				newAttributes |= System.Reflection.FieldAttributes.FamANDAssem;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.Private) == Mono.Cecil.FieldAttributes.Private)
			{
				newAttributes |= System.Reflection.FieldAttributes.Private;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.Assembly) == Mono.Cecil.FieldAttributes.Assembly)
			{
				newAttributes |= System.Reflection.FieldAttributes.Assembly;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.FamORAssem) == Mono.Cecil.FieldAttributes.FamORAssem)
			{
				newAttributes |= System.Reflection.FieldAttributes.FamORAssem;
			}




			if ((attributes & Mono.Cecil.FieldAttributes.CompilerControlled) == Mono.Cecil.FieldAttributes.CompilerControlled)
			{
				newAttributes |= System.Reflection.FieldAttributes.PrivateScope;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.HasDefault) == Mono.Cecil.FieldAttributes.HasDefault)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasDefault;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.HasFieldMarshal) == Mono.Cecil.FieldAttributes.HasFieldMarshal)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasFieldMarshal;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.HasFieldRVA) == Mono.Cecil.FieldAttributes.HasFieldRVA)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasFieldRVA;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.InitOnly) == Mono.Cecil.FieldAttributes.InitOnly)
			{
				newAttributes |= System.Reflection.FieldAttributes.InitOnly;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.Literal) == Mono.Cecil.FieldAttributes.Literal)
			{
				newAttributes |= System.Reflection.FieldAttributes.Literal;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.NotSerialized) == Mono.Cecil.FieldAttributes.NotSerialized)
			{
				newAttributes |= System.Reflection.FieldAttributes.NotSerialized;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.PInvokeImpl) == Mono.Cecil.FieldAttributes.PInvokeImpl)
			{
				newAttributes |= System.Reflection.FieldAttributes.PinvokeImpl;
			}





			if ((attributes & Mono.Cecil.FieldAttributes.RTSpecialName) == Mono.Cecil.FieldAttributes.RTSpecialName)
			{
				newAttributes |= System.Reflection.FieldAttributes.RTSpecialName;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.SpecialName) == Mono.Cecil.FieldAttributes.SpecialName)
			{
				newAttributes |= System.Reflection.FieldAttributes.SpecialName;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.Static) == Mono.Cecil.FieldAttributes.Static)
			{
				newAttributes |= FieldAttributes.Static;
			}

			return newAttributes;

		}
	}
}
