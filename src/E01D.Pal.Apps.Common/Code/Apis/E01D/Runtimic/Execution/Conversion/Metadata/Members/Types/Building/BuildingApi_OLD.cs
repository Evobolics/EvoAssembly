//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Mono.Cecil;
//using Root.Code.Containers.E01D.Runtimic;
//using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
//using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
//using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
//using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
//using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
//using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
//using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
//using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
//using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
//using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
//using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
//using GenericParameterAttributes = System.Reflection.GenericParameterAttributes;

//namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building
//{
//    public class BuilderApi<TContainer> : ConversionApiNode<TContainer>, BuilderApi_I<TContainer>
//        where TContainer : RuntimicContainer_I<TContainer>
//    {
        

       

//        public void Build(ILConversion conversion, List<ConvertedTypeDefinition_I> list)
//        {
//            for (int i = 0; i < list.Count; i++)
//            {
//                var converted = list[i];

//                Build(conversion, converted);
//            }
//        }

//        public void Build(ILConversion conversion, ConvertedTypeDefinition_I convertedTypeDefinition)
//        {
//            // if the converted tyep definition has already been built by a recursive call, due to being a dependency
//            // to another type, then return and not build it again.
//            //if (convertedTypeDefinition.IsBuilt) return;

//            //convertedTypeDefinition.IsBuilt = true;

//            //if (IsClosedGeneric(convertedTypeDefinition, out ConvertedGenericTypeDefinition_I generic))
//            //{
//            //    System.Type blueprintType = Models.Types.ResolveToType(conversion, generic.Blueprint, out BoundTypeDefinitionMask_I resultingBound);

//            //    Type[] typeArgumentTypes = GetTypeArgumentTypes(conversion, generic);

//            //    convertedTypeDefinition.UnderlyingType = blueprintType.MakeGenericType(typeArgumentTypes);

//            //    convertedTypeDefinition.IsBuilt = true;

//            //    convertedTypeDefinition.IsBaked = true;

//            //    return;
//            //}
//            //if (convertedTypeDefinition.IsArrayType())
//            //{
//            //    //ArrayType arrayType = (ArrayType)convertedTypeDefinition.SourceTypeReference;

//            //    //var semanticArray = (SemanticArrayTypeDefinitionMask_I)convertedTypeDefinition;

//            //    //var elementType = Models.Types.ResolveToType(conversion, semanticArray.ElementType);

//            //    //if (arrayType.Rank == 1)
//            //    //{
//            //    //    // Makes a vector
//            //    //    convertedTypeDefinition.UnderlyingType = elementType.MakeArrayType();
//            //    //}
//            //    //else
//            //    //{
//            //    //    // Makes an multi-dimensional array
//            //    //    convertedTypeDefinition.UnderlyingType = elementType.MakeArrayType(arrayType.Rank);
//            //    //}

//            //    //convertedTypeDefinition.IsBuilt = true;

//            //    //convertedTypeDefinition.IsBaked = true;

//            //    //return;
//            //}

            

//            //// Need to do this first, in case any of the type parameter builders are used as types in the following calls.
//            ////DefineTypeParameterBuildersIfPresent(conversion, convertedTypeDefinition);

//            ////GetBaseType(conversion, convertedTypeDefinition);

//            ////SetInterfaces(conversion, convertedTypeDefinition);

//            //// If a generic without a type definition, return;
//            ////if (input is SemanticGenericTypeDefinition_I genericTypeDefinition && genericTypeDefinition.GenericTypeDefinition != null) continue;

//            ////BuildNestedTypes(conversion, convertedTypeDefinition);

//            //Fields.Building.BuildFields(conversion, convertedTypeDefinition);

//            //Methods.Building.BuildMethods(conversion, convertedTypeDefinition);

//            //Properties.Building.BuildsProperties(conversion, convertedTypeDefinition);

//            //Events.Building.BuildEvents(conversion, convertedTypeDefinition);

//            //Instructions.Building.BuildInstructions(conversion, convertedTypeDefinition);

//            //Types.Baking.Bake(conversion, convertedTypeDefinition);
   
//        }

//        private void BuildNestedTypes(ILConversion conversion, ConvertedTypeDefinition_I convertedTypeDefinition)
//        {
//            var nestedTypes = convertedTypeDefinition.NestedTypes.Values.ToList();

//            for (int i = 0; i < nestedTypes.Count; i++)
//            {
//                var nestedType = nestedTypes[i];

//                if (!nestedType.IsConverted())
//                {
//                    throw new Exception("Cannot convert a nested type that is not convertible.");
//                }

//                Build(conversion, (ConvertedTypeDefinition_I)nestedType);
//            }
//        }

//        private void SetInterfaces(ILConversion conversion, ConvertedTypeDefinition_I convertedTypeDefinition)
//        {
//            if (convertedTypeDefinition.SupportsInterfaceTypeList())
//            {
//                var withInterfaces = convertedTypeDefinition as SemanticTypeWithInterfaceTypeList_I;

//                if (withInterfaces == null)
//                {
//                    throw new Exception("The type should have implemented the interface BoundTypeWithInterfaceTypeList_I");
//                }

//                Type[] interfaces = GetInterfaces(conversion, withInterfaces);

//                for (int i = 0; i < interfaces.Length; i++)
//                {
//                    convertedTypeDefinition.TypeBuilder.AddInterfaceImplementation(interfaces[i]);
//                }
//            }
//        }
        
        

//        private Type[] GetTypeArgumentTypes(ILConversion conversion, ConvertedGenericTypeDefinition_I generic)
//        {
//            Type[] typeArgumentTypes = new Type[generic.TypeArguments.All.Count];

//            for (int i = 0; i < typeArgumentTypes.Length; i++)
//            {
//                typeArgumentTypes[i] = Types.Ensuring.EnsureToType(conversion, generic.TypeArguments.All[i]);
//            }

//            return typeArgumentTypes;
//        }

       

//        private static bool IsClosedGeneric(ConvertedTypeDefinition_I convertedTypeDefinition, out ConvertedGenericTypeDefinition_I genericOut)
//        {
//            if (convertedTypeDefinition.IsGeneric() && convertedTypeDefinition is ConvertedGenericTypeDefinition_I generic && generic.IsClosedType())
//            {
//                genericOut = generic;

//                return true;
//            }

//            genericOut = null;

//            return false;
//        }

//        public System.Type GetBaseType(ILConversion conversion, ConvertedTypeDefinition_I convertedTypeDefinition)
//        {
            

//            if (convertedTypeDefinition.BaseType != null && convertedTypeDefinition.BaseType.IsConverted())
//            {
//                ConvertedTypeDefinition_I convertedBaseType = (ConvertedTypeDefinition_I)convertedTypeDefinition.BaseType;

//                if (!convertedBaseType.IsBuilt)
//                {
//                    Build(conversion, convertedBaseType);
//                }
//            }

//            var boundBaseType = Binding.Models.Types.GetBoundTypeOrThrow(convertedTypeDefinition.BaseType, true);

//            System.Type baseType;

//            if (convertedTypeDefinition.IsStruct())
//            {
//                baseType = boundBaseType?.UnderlyingType ?? GetValueType(conversion.Model);
//            }
//            else
//            {
//                // Done on purpose to find errors
//                var typeDefinition = (TypeDefinition) convertedTypeDefinition.SourceTypeReference;

//                baseType = boundBaseType?.UnderlyingType ?? (typeDefinition.IsClass ? GetObjectType(conversion.Model) : null);
//            }

//            if (baseType == null && (convertedTypeDefinition.IsClassType() || convertedTypeDefinition.IsStruct()))
//            {
//                throw new Exception("The bound's undelrying type cannot be null.  The converted type is a class or struct, and in either case requires a base class of either System.Object or System.ValueType.");
//            }

//            convertedTypeDefinition.TypeBuilder.SetParent(baseType);

//            return baseType;
//        }

//        private static ConvertedModule_I GetConvertedModule(ConvertedTypeDefinition_I convertedTypeDefinition)
//        {
//            var moduleEntry = convertedTypeDefinition.Module;

//            if (moduleEntry == null)
//            {
//                throw new Exception("Expected the module entry associated with the converted type definition not to be null.");
//            }

//            if (!(moduleEntry is ConvertedModule_I convertedModule))
//            {
//                throw new Exception("Expected the module entry associated with the converted type definition to be a converted module.");
//            }

//            return convertedModule;
//        }

        

//        private void DefineTypeParameterBuildersIfPresent(ILConversion conversion, ConvertedTypeDefinition_I convertedType)
//        {
//            if (!convertedType.IsGeneric()) return;

//            var gtd = (ConvertedGenericTypeDefinition_I) convertedType;

//            if (!gtd.HasTypeParameters()) return;

//            var ctwtb = (ConvertedTypeDefinitionWithTypeBuilder_I) convertedType;

//            var tpList = gtd.TypeParameters.All;

//            var names = Types.TypeParameters.GetNames(conversion, gtd);

//            var genericParameters = convertedType.TypeBuilder.DefineGenericParameters(names);

//            gtd.TypeParameters.Builders = genericParameters;

//            for (var i = 0; i < tpList.Count; i++)
//            {
//                var tp = (ConvertedGenericParameterTypeDefinition)tpList[i];

//                tp.Builder = genericParameters[i];

//                tp.UnderlyingType = genericParameters[i];

//                var genericParameterAttributes = GetGenericParameterAttributes(tp.Attributes);

//                tp.Builder.SetGenericParameterAttributes(genericParameterAttributes);

//                if (tp.InterfaceTypeConstraints != null && tp.InterfaceTypeConstraints.Count > 0)
//                {
//                    var interfaceTypes = GetInterfaceTypeConstraints(conversion, tp.InterfaceTypeConstraints);

//                    tp.Builder.SetInterfaceConstraints(interfaceTypes);
//                }

//                var baseTypeConstraint = GetBaseTypeConstraint(conversion, tp.BaseTypeConstraint);

//                if (baseTypeConstraint != null)
//                {
//                    tp.Builder.SetBaseTypeConstraint(baseTypeConstraint);
//                }

//                Types.Baking.MarkAsBaked(tp);
//            }
//        }

//        private Type GetBaseTypeConstraint(ILConversion conversion, ConvertedClassTypeParameterConstraint tpBaseTypeConstraint)
//        {
//            if (tpBaseTypeConstraint == null) return null;

//            if (tpBaseTypeConstraint.Class == null)
//            {
//                throw new Exception("The class of a base type constraint should not be null.");
//            }

//            if (tpBaseTypeConstraint.Class.IsConverted())
//            {
//                ConvertedTypeDefinition_I convertedInterface = (ConvertedTypeDefinition_I)tpBaseTypeConstraint.Class;

//                if (!convertedInterface.IsBuilt)
//                {
//                    Build(conversion, convertedInterface);
//                }
//            }

//            var result = Models.Types.GetBoundUnderlyingTypeOrThrow(tpBaseTypeConstraint.Class);

//            return result;
//        }

//        private Type[] GetInterfaceTypeConstraints(ILConversion conversion, List<ConvertedInterfaceTypeParameterConstraint> tpInterfaceTypeConstraints)
//        {
//            var types = new List<Type>();

//            foreach (var x in tpInterfaceTypeConstraints)
//            {
//                if (x.Interface == null)
//                {
//                    throw new Exception("The interface of a constraint should not be null.");
//                }

//                if (x.Interface != null && x.Interface.IsConverted())
//                {
//                    ConvertedTypeDefinition_I convertedInterface = (ConvertedTypeDefinition_I)x.Interface;

//                    if (!convertedInterface.IsBuilt)
//                    {
//                        Build(conversion, convertedInterface);
//                    }
//                }

//                var result = Models.Types.GetBoundUnderlyingTypeOrThrow(x.Interface);

//                types.Add(result);
//            }

//            return types.ToArray();
//        }

//        private GenericParameterAttributes GetGenericParameterAttributes(GenericParameter tpGenericParameterDefinition)
//        {
//            var x = GenericParameterAttributes.None;

//            if (tpGenericParameterDefinition.HasDefaultConstructorConstraint)
//            {
//                x |= GenericParameterAttributes.DefaultConstructorConstraint;
//            }
//            if (tpGenericParameterDefinition.HasNotNullableValueTypeConstraint)
//            {
//                x |= GenericParameterAttributes.NotNullableValueTypeConstraint;
//            }
//            if (tpGenericParameterDefinition.HasReferenceTypeConstraint)
//            {
//                x |= GenericParameterAttributes.ReferenceTypeConstraint;
//            }
//            if (tpGenericParameterDefinition.IsContravariant)
//            {
//                x |= GenericParameterAttributes.Contravariant;
//            }
//            if (tpGenericParameterDefinition.IsCovariant)
//            {
//                x |= GenericParameterAttributes.Covariant;
//            }
            
//            return x;
//        }

//        private GenericParameterAttributes GetGenericParameterAttributes(TypeParameterConstraintKind attributes)
//        {
//            var x = GenericParameterAttributes.None;

//            if ((attributes & TypeParameterConstraintKind.DefaultConstructorConstraint) == TypeParameterConstraintKind.DefaultConstructorConstraint)
//            {
//                x |= GenericParameterAttributes.DefaultConstructorConstraint;
//            }
//            if ((attributes & TypeParameterConstraintKind.NotNullableValueTypeConstraint) == TypeParameterConstraintKind.NotNullableValueTypeConstraint)
//            {
//                x |= GenericParameterAttributes.NotNullableValueTypeConstraint;
//            }
//            if ((attributes & TypeParameterConstraintKind.ReferenceTypeConstraint) == TypeParameterConstraintKind.ReferenceTypeConstraint)
//            {
//                x |= GenericParameterAttributes.ReferenceTypeConstraint;
//            }
//            if ((attributes & TypeParameterConstraintKind.Contravariant) == TypeParameterConstraintKind.Contravariant)
//            {
//                x |= GenericParameterAttributes.Contravariant;
//            }
//            if ((attributes & TypeParameterConstraintKind.Covariant) == TypeParameterConstraintKind.Covariant)
//            {
//                x |= GenericParameterAttributes.Covariant;
//            }

//            return x;
//        }

        

//        private Type[] GetInterfaces(ILConversion conversion, SemanticTypeWithInterfaceTypeList_I withInterfaces)
//        {
//            List<Type> types = new List<Type>();

//            var interfaces = withInterfaces.Interfaces.ByResolutionName.Values.ToList();

//            for (int i = 0; i < interfaces.Count; i++)
//            {
//                var currentInterface = interfaces[i];

//                if (currentInterface != null && currentInterface.IsConverted())
//                {
//                    ConvertedTypeDefinition_I convertedBaseType = (ConvertedTypeDefinition_I)currentInterface;

//                    if (!convertedBaseType.IsBuilt)
//                    {
//                        Build(conversion, convertedBaseType);
//                    }
//                }

//                if (currentInterface is BoundTypeDefinitionMask_I boundType)
//                {
//                    types.Add(boundType.UnderlyingType);
//                }
//                else
//                {
//                    throw new Exception("Expected a bound type definition when getting the interface.");
//                }
//            }

//            return types.ToArray();
//        }

        

//        private System.Type GetObjectType(InfrastructureModel_I model)
//        {
//            return Binding.Models.Types.GetObjectType(model);
//        }

//        private System.Type GetValueType(InfrastructureModel_I model)
//        {
//            return Binding.Models.Types.GetValueType(model);
//        }

//        private System.Type GetEnumType(InfrastructureModel_I model)
//        {
//            return Binding.Models.Types.GetEnumType(model);
//        }

//        //if (convertedTypeDefinition.IsNestedType())
//        //{
//        //var nestedEnum = (ConvertedNestedEnumTypeDefinition)enumPart;

//        //    var declaringType = (ConvertedNonEnumTypePart_I)nestedEnum.DeclaringType;

//        //    // https://msdn.microsoft.com/en-us/library/system.reflection.emit.typebuilder.createtype.aspx
//        //    nestedEnum.TypeBuilder = declaringType.TypeBuilder.DefineNestedType(typeDefinition.FullName, attributes, GetEnumType(conversion.Model), null);

//        //    nestedEnum.UnderlyingType = nestedEnum.TypeBuilder;

//        //    nestedEnum.TypeBuilder.inter
//        //}
//        //else
//        //{
//        //    enumPart.EnumBuilder = convertedModule.ModuleBuilder.DefineEnum(typeDefinition.FullName, attributes, baseType);

//        //    enumPart.UnderlyingType = enumPart.EnumBuilder;
//        //}


//        //if (convertedTypeDefinition.SupportsInterfaceTypeList())
//        //{
//        //    var withInterfaces = convertedTypeDefinition as SemanticTypeWithInterfaceTypeList_I;

//        //    if (withInterfaces == null)
//        //    {
//        //        throw new Exception(
//        //            "The type should have implemented the interface BoundTypeWithInterfaceTypeList_I");
//        //    }

//        //    Type[] interfaces = GetInterfaces(conversion, withInterfaces);

//        //    if (convertedTypeDefinition.IsNestedType())
//        //    {
//        //        var withDeclaringType = (BoundMemberWithDeclaringTypeMask_I)convertedTypeDefinition;

//        //        var declaringType = (ConvertedTypeDefinitionMask_I)withDeclaringType.DeclaringType;

//        //        nonEnumPart.TypeBuilder = declaringType.TypeBuilder.DefineNestedType(typeDefinition.FullName, attributes, baseType, interfaces);
//        //    }
//        //    else
//        //    {
//        //        nonEnumPart.TypeBuilder = convertedModule.ModuleBuilder.DefineType(typeDefinition.FullName, attributes, baseType, interfaces);
//        //    }
//        //}
//        //else if (baseType != null && (baseType.FullName == "System.MulticastDelegate" || baseType.FullName == "Delegate"))
//        //{
//        //    if (convertedTypeDefinition.IsNestedType())
//        //    {
//        //        var withDeclaringType = (BoundMemberWithDeclaringTypeMask_I)convertedTypeDefinition;

//        //        var declaringType = (ConvertedTypeDefinitionMask_I)withDeclaringType.DeclaringType;

//        //        nonEnumPart.TypeBuilder = declaringType.TypeBuilder.DefineNestedType(typeDefinition.FullName, attributes, baseType);
//        //    }
//        //    else
//        //    {
//        //        nonEnumPart.TypeBuilder = convertedModule.ModuleBuilder.DefineType(typeDefinition.FullName, attributes, baseType);
//        //    }
//        //}
//        //else
//        //{
//        //    if (convertedTypeDefinition.IsNestedType())
//        //    {
//        //        var withDeclaringType = (BoundMemberWithDeclaringTypeMask_I)convertedTypeDefinition;

//        //        var declaringType = (ConvertedTypeDefinitionMask_I)withDeclaringType.DeclaringType;

//        //        nonEnumPart.TypeBuilder = declaringType.TypeBuilder.DefineNestedType(typeDefinition.FullName, attributes, baseType, typeDefinition.PackingSize);
//        //    }
//        //    else
//        //    {
//        //        nonEnumPart.TypeBuilder = convertedModule.ModuleBuilder.DefineType(typeDefinition.FullName, attributes, baseType, typeDefinition.PackingSize);
//        //    }
//        //}

//        //nonEnumPart.UnderlyingType = nonEnumPart.TypeBuilder;
//    }
//}
