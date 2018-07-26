//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2015 Jb Evain
// Copyright (c) 2008 - 2011 Novell, Inc.
//
// Licensed under the MIT/X11 license.
//

using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Metadata;
using Root.Code.Libs.Mono.Collections.Generic;

namespace Root.Code.Libs.Mono.Cecil
{

	public enum MetadataType : byte {
		Void = CecilElementType.Void,
		Boolean = CecilElementType.Boolean,
		Char = CecilElementType.Char,
		SByte = CecilElementType.I1,
		Byte = CecilElementType.U1,
		Int16 = CecilElementType.I2,
		UInt16 = CecilElementType.U2,
		Int32 = CecilElementType.I4,
		UInt32 = CecilElementType.U4,
		Int64 = CecilElementType.I8,
		UInt64 = CecilElementType.U8,
		Single = CecilElementType.R4,
		Double = CecilElementType.R8,
		String = CecilElementType.String,
		Pointer = CecilElementType.Ptr,
		ByReference = CecilElementType.ByRef,
		ValueType = CecilElementType.ValueType,
		Class = CecilElementType.Class,
		Var = CecilElementType.Var,
		Array = CecilElementType.Array,
		GenericInstance = CecilElementType.GenericInst,
		TypedByReference = CecilElementType.TypedByRef,
		IntPtr = CecilElementType.I,
		UIntPtr = CecilElementType.U,
		FunctionPointer = CecilElementType.FnPtr,
		Object = CecilElementType.Object,
		MVar = CecilElementType.MVar,
		RequiredModifier = CecilElementType.CModReqD,
		OptionalModifier = CecilElementType.CModOpt,
		Sentinel = CecilElementType.Sentinel,
		Pinned = CecilElementType.Pinned,
	}

	public class TypeReference : MemberReference, IGenericParameterProvider, IGenericContext {

		string @namespace;
		bool value_type;
		internal IMetadataScope scope;
		internal ModuleDefinition module;

		internal CecilElementType etype = CecilElementType.None;

		string fullname;

		protected Collection<GenericParameter> generic_parameters;

		public override string Name {
			get { return base.Name; }
			set {
				if (IsWindowsRuntimeProjection && value != base.Name)
					throw new InvalidOperationException ("Projected type reference name can't be changed.");
				base.Name = value;
				ClearFullName ();
			}
		}

		public virtual string Namespace {
			get { return @namespace; }
			set {
				if (IsWindowsRuntimeProjection && value != @namespace)
					throw new InvalidOperationException ("Projected type reference namespace can't be changed.");
				@namespace = value;
				ClearFullName ();
			}
		}

		public virtual bool IsValueType {
			get { return value_type; }
			set { value_type = value; }
		}

		public override ModuleDefinition Module {
			get {
				if (module != null)
					return module;

				var declaring_type = this.DeclaringType;
				if (declaring_type != null)
					return declaring_type.Module;

				return null;
			}
		}

		internal new TypeReferenceProjection WindowsRuntimeProjection {
			get { return (TypeReferenceProjection) projection; }
			set { projection = value; }
		}

		IGenericParameterProvider IGenericContext.Type {
			get { return this; }
		}

		IGenericParameterProvider IGenericContext.Method {
			get { return null; }
		}

		GenericParameterType IGenericParameterProvider.GenericParameterType {
			get { return GenericParameterType.Type; }
		}

		public virtual bool HasGenericParameters {
			get { return !generic_parameters.IsNullOrEmpty (); }
		}

		public virtual Collection<GenericParameter> GenericParameters {
			get {
				if (generic_parameters != null)
					return generic_parameters;

				return generic_parameters = new GenericParameterCollection (this);
			}
		}

		public virtual IMetadataScope Scope {
			get {
				var declaring_type = this.DeclaringType;
				if (declaring_type != null)
					return declaring_type.Scope;

				return scope;
			}
			set {
				var declaring_type = this.DeclaringType;
				if (declaring_type != null) {
					if (IsWindowsRuntimeProjection && value != declaring_type.Scope)
						throw new InvalidOperationException ("Projected type scope can't be changed.");
					declaring_type.Scope = value;
					return;
				}

				if (IsWindowsRuntimeProjection && value != scope)
					throw new InvalidOperationException ("Projected type scope can't be changed.");
				scope = value;
			}
		}

		public bool IsNested {
			get { return this.DeclaringType != null; }
		}

		public override TypeReference DeclaringType {
			get { return base.DeclaringType; }
			set {
				if (IsWindowsRuntimeProjection && value != base.DeclaringType)
					throw new InvalidOperationException ("Projected type declaring type can't be changed.");
				base.DeclaringType = value;
				ClearFullName ();
			}
		}

		public override string FullName {
			get {
				if (fullname != null)
					return fullname;

				fullname = this.TypeFullName ();

				if (IsNested)
					fullname = DeclaringType.FullName + "/" + fullname;

				return fullname;
			}
		}

		public virtual bool IsByReference {
			get { return false; }
		}

		public virtual bool IsPointer {
			get { return false; }
		}

		public virtual bool IsSentinel {
			get { return false; }
		}

		public virtual bool IsArray {
			get { return false; }
		}

		public virtual bool IsGenericParameter {
			get { return false; }
		}

		public virtual bool IsGenericInstance {
			get { return false; }
		}

		public virtual bool IsRequiredModifier {
			get { return false; }
		}

		public virtual bool IsOptionalModifier {
			get { return false; }
		}

		public virtual bool IsPinned {
			get { return false; }
		}

		public virtual bool IsFunctionPointer {
			get { return false; }
		}

		public virtual bool IsPrimitive {
			get { return etype.IsPrimitive (); }
		}

		public CecilElementType ElementKind
		{
			get { return etype; }
			set { etype = value; }
		}

		public virtual MetadataType MetadataType {
			get {
				switch (etype) {
				case CecilElementType.None:
					return IsValueType ? MetadataType.ValueType : MetadataType.Class;
				default:
					return (MetadataType) etype;
				}
			}
		}

		protected TypeReference (string @namespace, string name)
			: base (name)
		{
			this.@namespace = @namespace ?? string.Empty;
			this.token = new MetadataToken (TokenType.TypeRef, 0);
		}

		public TypeReference (string @namespace, string name, ModuleDefinition module, IMetadataScope scope)
			: this (@namespace, name)
		{
			this.module = module;
			this.scope = scope;
		}

		public TypeReference (string @namespace, string name, ModuleDefinition module, IMetadataScope scope, bool valueType) :
			this (@namespace, name, module, scope)
		{
			value_type = valueType;
		}

		protected virtual void ClearFullName ()
		{
			this.fullname = null;
		}

		public virtual TypeReference GetElementType ()
		{
			return this;
		}

		protected override IMemberDefinition ResolveDefinition ()
		{
			return this.Resolve ();
		}

		public new virtual TypeDefinition Resolve ()
		{
			var module = this.Module;
			if (module == null)
				throw new NotSupportedException ();

			return module.Resolve (this);
		}
	}

	static partial class Mixin {

		public static bool IsPrimitive (this CecilElementType self)
		{
			switch (self) {
			case CecilElementType.Boolean:
			case CecilElementType.Char:
			case CecilElementType.I:
			case CecilElementType.U:
			case CecilElementType.I1:
			case CecilElementType.U1:
			case CecilElementType.I2:
			case CecilElementType.U2:
			case CecilElementType.I4:
			case CecilElementType.U4:
			case CecilElementType.I8:
			case CecilElementType.U8:
			case CecilElementType.R4:
			case CecilElementType.R8:
				return true;
			default:
				return false;
			}
		}

		public static string TypeFullName (this TypeReference self)
		{
			return string.IsNullOrEmpty (self.Namespace)
				? self.Name
				: self.Namespace + '.' + self.Name;
		}

		public static bool IsTypeOf (this TypeReference self, string @namespace, string name)
		{
			return self.Name == name
				&& self.Namespace == @namespace;
		}

		public static bool IsTypeSpecification (this TypeReference type)
		{
			switch (type.etype) {
			case CecilElementType.Array:
			case CecilElementType.ByRef:
			case CecilElementType.CModOpt:
			case CecilElementType.CModReqD:
			case CecilElementType.FnPtr:
			case CecilElementType.GenericInst:
			case CecilElementType.MVar:
			case CecilElementType.Pinned:
			case CecilElementType.Ptr:
			case CecilElementType.SzArray:
			case CecilElementType.Sentinel:
			case CecilElementType.Var:
				return true;
			}

			return false;
		}

		public static TypeDefinition CheckedResolve (this TypeReference self)
		{
			var type = self.Resolve ();
			if (type == null)
				throw new ResolutionException (self);

			return type;
		}
	}
}
