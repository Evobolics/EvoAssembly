using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public class TypeApi<TContainer> : CecilApiNode<TContainer>, TypeApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public AddingApi_I<TContainer> Adding { get; set; }

		AddingApiMask_I TypeApiMask_I.Adding => Adding;

		public EnsuringApi_I<TContainer> Ensuring { get; set; }

		EnsuringApiMask_I TypeApiMask_I.Ensuring => Ensuring;

		public ExtendingApi_I<TContainer> Extending { get; set; }

		ExtendingApiMask_I TypeApiMask_I.Extending => Extending;

		public ExternalApi_I<TContainer> External { get; set; }

		ExternalApiMask_I TypeApiMask_I.External => External;

		public GettingApi_I<TContainer> Getting { get; set; }

		GettingApiMask_I TypeApiMask_I.Getting => Getting;

		public LoadingApi_I<TContainer> Loading { get; set; }

		LoadingApiMask_I TypeApiMask_I.Loading => Loading;

		public NamingApi_I<TContainer> Naming { get; set; }

		NamingApiMask_I TypeApiMask_I.Naming => Naming;



		



		public System.Reflection.TypeAttributes GetTypeAttributes(TypeDefinition typeDefinition)
		{
			System.Reflection.TypeAttributes typeAttributes = default(System.Reflection.TypeAttributes);

			if ((typeDefinition.Attributes & TypeAttributes.Abstract) == TypeAttributes.Abstract)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Abstract;
			}

			if ((typeDefinition.Attributes & TypeAttributes.AnsiClass) == TypeAttributes.AnsiClass)
			{
				// the Value is zero, so it really does not do anything.
				typeAttributes |= System.Reflection.TypeAttributes.AnsiClass;
			}

			if ((typeDefinition.Attributes & TypeAttributes.AutoClass) == TypeAttributes.AutoClass)
			{
				typeAttributes |= System.Reflection.TypeAttributes.AutoClass;
			}

			if ((typeDefinition.Attributes & TypeAttributes.AutoLayout) == TypeAttributes.AutoLayout)
			{
				typeAttributes |= System.Reflection.TypeAttributes.AutoLayout;
			}

			if ((typeDefinition.Attributes & TypeAttributes.BeforeFieldInit) == TypeAttributes.BeforeFieldInit)
			{
				typeAttributes |= System.Reflection.TypeAttributes.BeforeFieldInit;
			}

			if ((typeDefinition.Attributes & TypeAttributes.Class) == TypeAttributes.Class)
			{
				// the Value is zero, so it really does not do anything.
				typeAttributes |= System.Reflection.TypeAttributes.Class;
			}

			if ((typeDefinition.Attributes & TypeAttributes.ExplicitLayout) == TypeAttributes.ExplicitLayout)
			{
				typeAttributes |= System.Reflection.TypeAttributes.ExplicitLayout;
			}

			if ((typeDefinition.Attributes & TypeAttributes.HasSecurity) == TypeAttributes.HasSecurity)
			{
				typeAttributes |= System.Reflection.TypeAttributes.HasSecurity;
			}

			if ((typeDefinition.Attributes & TypeAttributes.Import) == TypeAttributes.Import)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Import;
			}

			if ((typeDefinition.Attributes & TypeAttributes.Interface) == TypeAttributes.Interface)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Interface;
			}

			if ((typeDefinition.Attributes & TypeAttributes.NestedFamANDAssem) == TypeAttributes.NestedFamANDAssem)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedFamANDAssem;
			}

			if ((typeDefinition.Attributes & TypeAttributes.NestedAssembly) == TypeAttributes.NestedAssembly)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedAssembly;
			}

			if ((typeDefinition.Attributes & TypeAttributes.NestedFamORAssem) == TypeAttributes.NestedFamORAssem)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedFamORAssem;
			}

			if ((typeDefinition.Attributes & TypeAttributes.NestedFamily) == TypeAttributes.NestedFamily)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedFamily;
			}

			if ((typeDefinition.Attributes & TypeAttributes.NestedPrivate) == TypeAttributes.NestedPrivate)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedPrivate;
			}

			if ((typeDefinition.Attributes & TypeAttributes.NestedPublic) == TypeAttributes.NestedPublic)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedPublic;
			}

			if ((typeDefinition.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NotPublic;
			}

			if ((typeDefinition.Attributes & TypeAttributes.Public) == TypeAttributes.Public)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Public;
			}

			if ((typeDefinition.Attributes & TypeAttributes.RTSpecialName) == TypeAttributes.RTSpecialName)
			{
				typeAttributes |= System.Reflection.TypeAttributes.RTSpecialName;
			}

			if ((typeDefinition.Attributes & TypeAttributes.Sealed) == TypeAttributes.Sealed)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Sealed;
			}

			if ((typeDefinition.Attributes & TypeAttributes.SequentialLayout) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.SequentialLayout;
			}

			if ((typeDefinition.Attributes & TypeAttributes.Serializable) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Serializable;
			}

			if ((typeDefinition.Attributes & TypeAttributes.SpecialName) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.SpecialName;
			}

			if ((typeDefinition.Attributes & TypeAttributes.UnicodeClass) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.UnicodeClass;
			}

			if ((typeDefinition.Attributes & TypeAttributes.WindowsRuntime) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.WindowsRuntime;
			}

			return typeAttributes;
		}

		public bool IsClass(StructuralRuntimicModelMask_I model, TypeReference constraint)
		{
			if (constraint.IsDefinition)
			{
				var definition = (TypeDefinition)constraint;

				return definition.IsClass;
			}
			if (constraint.IsGenericInstance)
			{
				var genericInstance = (GenericInstanceType)constraint;

				// In case the reference is external.
				return IsClass(model, genericInstance.ElementType);

				//var definition = (TypeDefinition)genericInstance.ElementType;

				//return definition.IsClass;
			}

			if (IsExternal(constraint))
			{
				var external = External.Resolve(model, constraint);

				return IsClass(model, external);
			}
			throw new Exception("Is class only implemented for definitions so far.");
		}

		public bool IsExternal(TypeReference typeReference)
		{
			if (typeReference.IsDefinition) return false;
			if (typeReference.IsGenericInstance) return false;
			if (typeReference.IsGenericParameter) return false;
			if (typeReference.IsPointer) return false;
			if (typeReference.IsRequiredModifier) return false;
			if (typeReference.IsArray) return false;
			if (typeReference.IsFunctionPointer) return false;
			//if (typeReference.IsPrimitive) return false;
			if (typeReference.IsSentinel) return false;
			//if (typeReference.IsValueType) return false;

			return true;
		}

		public bool AreSame(TypeSpecification a, TypeSpecification b)
		{
			if (!AreSame(a.ElementType, b.ElementType))
				return false;

			if (a.IsGenericInstance)
				return AreSame((GenericInstanceType)a, (GenericInstanceType)b);

			if (a.IsRequiredModifier || a.IsOptionalModifier)
				return AreSame((IModifierType)a, (IModifierType)b);

			if (a.IsArray)
				return AreSame((ArrayType)a, (ArrayType)b);

			return true;
		}

		public bool AreSame(ArrayType a, ArrayType b)
		{
			if (a.Rank != b.Rank)
				return false;

			// TODO: dimensions

			return true;
		}

		public bool AreSame(IModifierType a, IModifierType b)
		{
			return AreSame(a.ModifierType, b.ModifierType);
		}

		public bool AreSame(GenericInstanceType a, GenericInstanceType b)
		{
			if (a.GenericArguments.Count != b.GenericArguments.Count)
				return false;

			for (int i = 0; i < a.GenericArguments.Count; i++)
				if (!AreSame(a.GenericArguments[i], b.GenericArguments[i]))
					return false;

			return true;
		}

		public bool AreSame(GenericParameter a, GenericParameter b)
		{
			return a.Position == b.Position;
		}

		public bool AreSame(TypeReference a, TypeReference b)
		{
			if (ReferenceEquals(a, b))
				return true;

			if (a == null || b == null)
				return false;

			if (a.ElementKind != b.ElementKind)
				return false;

			if (a.IsGenericParameter)
				return AreSame((GenericParameter)a, (GenericParameter)b);

			if (IsTypeSpecification(a))
				return AreSame((TypeSpecification)a, (TypeSpecification)b);

			if (a.Name != b.Name || a.Namespace != b.Namespace)
				return false;

			//TODO: check scope (aka Module and and Assembly)

			return AreSame(a.DeclaringType, b.DeclaringType);
		}

		public bool IsTypeSpecification(TypeReference type)
		{
			switch (type.ElementKind)
			{
				case ElementType.Array:
				case ElementType.ByRef:
				case ElementType.CModOpt:
				case ElementType.CModReqD:
				case ElementType.FnPtr:
				case ElementType.GenericInst:
				case ElementType.MVar:
				case ElementType.Pinned:
				case ElementType.Ptr:
				case ElementType.SzArray:
				case ElementType.Sentinel:
				case ElementType.Var:
					return true;
			}

			return false;
		}
	}
}
