using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
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

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.Abstract) == Mono.Cecil.TypeAttributes.Abstract)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Abstract;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.AnsiClass) == Mono.Cecil.TypeAttributes.AnsiClass)
			{
				// the Value is zero, so it really does not do anything.
				typeAttributes |= System.Reflection.TypeAttributes.AnsiClass;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.AutoClass) == Mono.Cecil.TypeAttributes.AutoClass)
			{
				typeAttributes |= System.Reflection.TypeAttributes.AutoClass;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.AutoLayout) == Mono.Cecil.TypeAttributes.AutoLayout)
			{
				typeAttributes |= System.Reflection.TypeAttributes.AutoLayout;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.BeforeFieldInit) == Mono.Cecil.TypeAttributes.BeforeFieldInit)
			{
				typeAttributes |= System.Reflection.TypeAttributes.BeforeFieldInit;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.Class) == Mono.Cecil.TypeAttributes.Class)
			{
				// the Value is zero, so it really does not do anything.
				typeAttributes |= System.Reflection.TypeAttributes.Class;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.ExplicitLayout) == Mono.Cecil.TypeAttributes.ExplicitLayout)
			{
				typeAttributes |= System.Reflection.TypeAttributes.ExplicitLayout;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.HasSecurity) == Mono.Cecil.TypeAttributes.HasSecurity)
			{
				typeAttributes |= System.Reflection.TypeAttributes.HasSecurity;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.Import) == Mono.Cecil.TypeAttributes.Import)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Import;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.Interface) == Mono.Cecil.TypeAttributes.Interface)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Interface;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.NestedFamANDAssem) == Mono.Cecil.TypeAttributes.NestedFamANDAssem)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedFamANDAssem;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.NestedAssembly) == Mono.Cecil.TypeAttributes.NestedAssembly)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedAssembly;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.NestedFamORAssem) == Mono.Cecil.TypeAttributes.NestedFamORAssem)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedFamORAssem;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.NestedFamily) == Mono.Cecil.TypeAttributes.NestedFamily)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedFamily;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.NestedPrivate) == Mono.Cecil.TypeAttributes.NestedPrivate)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedPrivate;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.NestedPublic) == Mono.Cecil.TypeAttributes.NestedPublic)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NestedPublic;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.NotPublic) == Mono.Cecil.TypeAttributes.NotPublic)
			{
				typeAttributes |= System.Reflection.TypeAttributes.NotPublic;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.Public) == Mono.Cecil.TypeAttributes.Public)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Public;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.RTSpecialName) == Mono.Cecil.TypeAttributes.RTSpecialName)
			{
				typeAttributes |= System.Reflection.TypeAttributes.RTSpecialName;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.Sealed) == Mono.Cecil.TypeAttributes.Sealed)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Sealed;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.SequentialLayout) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.SequentialLayout;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.Serializable) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.Serializable;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.SpecialName) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.SpecialName;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.UnicodeClass) > 0)
			{
				typeAttributes |= System.Reflection.TypeAttributes.UnicodeClass;
			}

			if ((typeDefinition.Attributes & Mono.Cecil.TypeAttributes.WindowsRuntime) > 0)
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
			if (typeReference.IsPrimitive) return false;
			if (typeReference.IsSentinel) return false;
			if (typeReference.IsValueType) return false;

			return true;
		}
	}
}
