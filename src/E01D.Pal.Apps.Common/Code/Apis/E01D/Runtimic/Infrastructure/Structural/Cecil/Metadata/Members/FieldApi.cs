using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
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

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.Public) == Libs.Mono.Cecil.FieldAttributes.Public)
			{
				newAttributes |= System.Reflection.FieldAttributes.Public;
			}
			if ((attributes & Libs.Mono.Cecil.FieldAttributes.Family) == Libs.Mono.Cecil.FieldAttributes.Family)
			{
				newAttributes |= System.Reflection.FieldAttributes.Family;
			}
			if ((attributes & Libs.Mono.Cecil.FieldAttributes.FamANDAssem) == Libs.Mono.Cecil.FieldAttributes.FamANDAssem)
			{
				newAttributes |= System.Reflection.FieldAttributes.FamANDAssem;
			}
			if ((attributes & Libs.Mono.Cecil.FieldAttributes.Private) == Libs.Mono.Cecil.FieldAttributes.Private)
			{
				newAttributes |= System.Reflection.FieldAttributes.Private;
			}
			if ((attributes & Libs.Mono.Cecil.FieldAttributes.Assembly) == Libs.Mono.Cecil.FieldAttributes.Assembly)
			{
				newAttributes |= System.Reflection.FieldAttributes.Assembly;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.FamORAssem) == Libs.Mono.Cecil.FieldAttributes.FamORAssem)
			{
				newAttributes |= System.Reflection.FieldAttributes.FamORAssem;
			}




			if ((attributes & Libs.Mono.Cecil.FieldAttributes.CompilerControlled) == Libs.Mono.Cecil.FieldAttributes.CompilerControlled)
			{
				newAttributes |= System.Reflection.FieldAttributes.PrivateScope;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.HasDefault) == Libs.Mono.Cecil.FieldAttributes.HasDefault)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasDefault;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.HasFieldMarshal) == Libs.Mono.Cecil.FieldAttributes.HasFieldMarshal)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasFieldMarshal;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.HasFieldRVA) == Libs.Mono.Cecil.FieldAttributes.HasFieldRVA)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasFieldRVA;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.InitOnly) == Libs.Mono.Cecil.FieldAttributes.InitOnly)
			{
				newAttributes |= System.Reflection.FieldAttributes.InitOnly;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.Literal) == Libs.Mono.Cecil.FieldAttributes.Literal)
			{
				newAttributes |= System.Reflection.FieldAttributes.Literal;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.NotSerialized) == Libs.Mono.Cecil.FieldAttributes.NotSerialized)
			{
				newAttributes |= System.Reflection.FieldAttributes.NotSerialized;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.PInvokeImpl) == Libs.Mono.Cecil.FieldAttributes.PInvokeImpl)
			{
				newAttributes |= System.Reflection.FieldAttributes.PinvokeImpl;
			}





			if ((attributes & Libs.Mono.Cecil.FieldAttributes.RTSpecialName) == Libs.Mono.Cecil.FieldAttributes.RTSpecialName)
			{
				newAttributes |= System.Reflection.FieldAttributes.RTSpecialName;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.SpecialName) == Libs.Mono.Cecil.FieldAttributes.SpecialName)
			{
				newAttributes |= System.Reflection.FieldAttributes.SpecialName;
			}

			if ((attributes & Libs.Mono.Cecil.FieldAttributes.Static) == Libs.Mono.Cecil.FieldAttributes.Static)
			{
				newAttributes |= FieldAttributes.Static;
			}

			return newAttributes;

		}
	}
}
