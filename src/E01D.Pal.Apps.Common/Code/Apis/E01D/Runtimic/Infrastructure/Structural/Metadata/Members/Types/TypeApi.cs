using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Rocks;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Members.Types
{
    public class TypeApi<TContainer> : RuntimeApiNode<TContainer>, TypeApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public StructuralTypeNode Ensure(RuntimicSystemModel model, Type type)
        {
            var rowId = type.MetadataToken & 0x00FFFFFF;

            bool isDerived = rowId < 1;

            if (isDerived)
            {
                if (type.IsPointer)
                {
                    var pointerStemType = Ensure(model, type.GetElementType());

                    if (pointerStemType.PointerType != null)
                    {
                        return pointerStemType.PointerType;
                    }

                    pointerStemType.PointerType = new StructuralTypeNode()
                    {
                        IsPointerType = true,
                        StemType = pointerStemType,
                        IsDerived = true,
                        MetadataToken = type.MetadataToken,
                        CecilTypeReference = pointerStemType.CecilTypeReference.MakeByReferenceType()
                    };

                    return pointerStemType.PointerType;
                }

                if (type.IsByRef)
                {
                    var byRefStemType = Ensure(model, type.GetElementType());

                    if (byRefStemType.ByRefType != null)
                    {
                        return byRefStemType.ByRefType;
                    }

                    byRefStemType.ByRefType = new StructuralTypeNode()
                    {
                        IsByReferenceType = true,
                        StemType = byRefStemType,
                        IsDerived = true,
                        MetadataToken = type.MetadataToken,
                        CecilTypeReference = byRefStemType.CecilTypeReference.MakeByReferenceType()
                    };

                    return byRefStemType.ByRefType;
                }

                throw new Exception("Derived type (arrays, generics?) not handled");

                
            }


            

            if (type.IsGenericType && !type.IsGenericTypeDefinition)
            {
                

                var genericDefinitionType = type.GetGenericTypeDefinition();

                var structuralDefinitionType = Ensure(model, genericDefinitionType);

                var argumentsTypes = type.GenericTypeArguments;



                StructuralTypeNode[] genericArguments = new StructuralTypeNode[argumentsTypes.Length];

                for (int i = 0; i < argumentsTypes.Length; i++)
                {
                    genericArguments[i] = Ensure(model, argumentsTypes[i]);
                }

                if (CheckForBranch(structuralDefinitionType, genericArguments, out StructuralGenericInstanceTypeNode structuralTypeNode))
                {
                    return structuralTypeNode;
                }

                TypeReference[] cecilArguments = GetCecilArguments(genericArguments);

                structuralTypeNode = new StructuralGenericInstanceTypeNode()
                {
                    StemType = structuralDefinitionType,
                    CecilTypeReference = structuralDefinitionType.CecilTypeReference.MakeGenericInstanceType(cecilArguments),
                    IsDerived = true,
                    FullName = type.FullName ?? type.Name,
                    IsGenericInstance = true,
                    GenericArguments = genericArguments

                };

                SetNode(structuralDefinitionType, structuralTypeNode);

                return structuralTypeNode;

            }


            var structuralAssembly = Infrastructure.Structural.Metadata.Assemblies.Ensuring.Ensure(model, type.Assembly);

            var structuralModuleNode = Infrastructure.Structural.Metadata.Modules.Ensure(model, structuralAssembly, type.Module.ModuleVersionId);

            // Have a derived type
            // Have a non-derived type / thus stored type
            var x = structuralModuleNode.CecilModuleDefinition.LookupToken(type.MetadataToken);

            var tableId = (int)(type.MetadataToken & 0xFF000000);

            if (!structuralModuleNode.Tables.TryGetValue(tableId, out StructuralTypeTable table))
            {
                table = new StructuralTypeTable();

                structuralModuleNode.Tables.Add(tableId, table);
            }

            if (!table.ByRow.TryGetValue((uint)rowId, out StructuralTypeNode structuralTypeNode1))
            {
                throw new Exception("Expected it to already be here.");
            }

            return structuralTypeNode1;
        }

        private TypeReference[] GetCecilArguments(StructuralTypeNode[] genericArguments)
        {
            TypeReference[] result = new TypeReference[genericArguments.Length];

            for (int i = 0; i < genericArguments.Length; i++)
            {
                result[i] = genericArguments[i].CecilTypeReference;
            }

            return result;
        }

        public StructuralTypeNode Ensure(RuntimicSystemModel model, TypeReference typeReference)
        {
            return Ensure(model, typeReference, null);
        }

        public StructuralTypeNode Ensure(RuntimicSystemModel model, TypeReference typeReference, TypeReference declaringType)
        {
            return Ensure(model, typeReference, declaringType, null);
        }

        public StructuralTypeNode Ensure(RuntimicSystemModel model, TypeReference typeReference, TypeReference declaringType, MethodReference declaringMethod)
        {
            var metadataToken = typeReference.MetadataToken.ToInt32();

            var rowId = metadataToken & 0x00FFFFFF;

            var tableId = (int)(metadataToken & 0xFF000000);

            bool isDerived = rowId < 1;

            
            if (typeReference.IsPointer)
            {
                var pointerStemType = Ensure(model, typeReference.GetElementType());

                if (pointerStemType.PointerType != null)
                {
                    return pointerStemType.PointerType;
                }

                pointerStemType.PointerType = new StructuralTypeNode()
                {
                    IsPointerType = true,
                    StemType = pointerStemType,
                    IsDerived = true,
                    MetadataToken = metadataToken,
                    CecilTypeReference = pointerStemType.CecilTypeReference.MakeByReferenceType()
                };

                return pointerStemType.PointerType;
            }

            if (typeReference.IsByReference)
            {
                var byRefStemType = Ensure(model, typeReference.GetElementType());

                if (byRefStemType.ByRefType != null)
                {
                    return byRefStemType.ByRefType;
                }

                byRefStemType.ByRefType = new StructuralTypeNode()
                {
                    IsByReferenceType = true,
                    StemType = byRefStemType,
                    IsDerived = true,
                    MetadataToken = metadataToken,
                    CecilTypeReference = byRefStemType.CecilTypeReference.MakeByReferenceType()
                };

                return byRefStemType.ByRefType;
            }

            if (typeReference.IsGenericInstance)
            {
                var genericInstanceType = (GenericInstanceType) typeReference;

                var genericDefinitionType = Ensure(model, genericInstanceType.ElementType);

                //var structuralModuleNode = GetModuleNode(model, typeReference);

                   

                StructuralTypeNode[] genericArguments = new StructuralTypeNode[genericInstanceType.GenericArguments.Count];

                for (int i = 0; i < genericInstanceType.GenericArguments.Count; i++)
                {
                    genericArguments[i] = Ensure(model, genericInstanceType.GenericArguments[i], genericInstanceType);
                }

                if (CheckForBranch(genericDefinitionType, genericArguments,
                    out StructuralGenericInstanceTypeNode structuralTypeNode))
                {
                    return structuralTypeNode;
                }

                structuralTypeNode = new StructuralGenericInstanceTypeNode()
                {
                    StemType = Ensure(model, typeReference.GetElementType()),
                    CecilTypeReference = typeReference,
                    MetadataToken = metadataToken,
                    //Module = structuralModuleNode,
                    IsDerived = true,
                    FullName = typeReference.FullName ?? typeReference.Name,
                    IsGenericParameter = typeReference.IsGenericParameter,
                    Signature = typeReference.Signature,
                    IsGenericInstance = true,
                    GenericArguments = genericArguments

                };

                SetNode(genericDefinitionType, structuralTypeNode);

                return structuralTypeNode;

            }

            if (typeReference.IsArray)
            {
                var arrayType = (ArrayType) typeReference;

                var arrayElementType = Ensure(model, typeReference.GetElementType());

                if (arrayElementType.Arrays != null && arrayElementType.Arrays.Length > 0)
                {
                    for (int i = 0; i < arrayElementType.Arrays.Length; i++)
                    {
                        var arrayNode = arrayElementType.Arrays[i];

                        if (arrayNode?.Rank == arrayType.Rank) return arrayNode;
                    }
                }

                var structuralTypeNode = new StructuralTypeNode()
                {
                    StemType = arrayElementType,
                    CecilTypeReference = typeReference,
                    MetadataToken = metadataToken,
                    Module = arrayElementType.Module,
                    IsDerived = true,
                    FullName = typeReference.FullName ?? typeReference.Name,
                    IsGenericParameter = typeReference.IsGenericParameter,
                    Signature = typeReference.Signature,
                    IsGenericInstance = false,
                    Rank = arrayType.Rank,
                    IsArrayType = true,

                };

                if (arrayElementType.Arrays == null)
                {
                    arrayElementType.Arrays = new StructuralTypeNode[5];
                }

                var foundSlot = false;
                int currentIndex = 0;
                    
                for (; currentIndex < arrayElementType.Arrays.Length; currentIndex++)
                {
                    var arrayNode = arrayElementType.Arrays[currentIndex];

                    if (arrayNode == null)
                    {
                        foundSlot = true;
                        break;
                    }
                }

                if (!foundSlot)
                {
                    var tempArrays = new StructuralTypeNode[arrayElementType.Arrays.Length+5];

                    Array.Copy(arrayElementType.Arrays, 0, tempArrays, 0, arrayElementType.Arrays.Length);

                    arrayElementType.Arrays = tempArrays;
                }

                arrayElementType.Arrays[currentIndex] = structuralTypeNode;

                return structuralTypeNode;



            }


            

            StructuralAssemblyNode structuralAssembly;

            switch (tableId)
            {
                case 0x01000000:
                {
                    structuralAssembly = Infrastructure.Structural.Metadata.Assemblies.Ensuring.Ensure(model, typeReference);

                    if (!structuralAssembly.Types.TryGetValue(typeReference.FullName, out StructuralTypeNode node))
                    {
                        throw new Exception("Could not resolve reference");
                    }

                    return node;
                }
                case 0x2a000000: // GenericParam
                {
                    var genericParameter = (GenericParameter)typeReference;

                    if (declaringMethod != null && genericParameter.Type== GenericParameterType.Method)
                    {
                        genericParameter = declaringMethod.GenericParameters[genericParameter.Position];

                        var methodReference = genericParameter.DeclaringMethod;

                        

                        genericParameter.Owner = declaringMethod;
                    }

                    if (rowId != 0)
                    {
                        var structuralModuleNode = GetModuleNode(model, typeReference);

                        return LookupStructuralTypeNode(structuralModuleNode, tableId, rowId);
                    }
                    else
                    {
                        if (genericParameter.Type == GenericParameterType.Type)
                        {
                            var declaringTypeNode = Ensure(model, genericParameter.DeclaringType, null);

                            return declaringTypeNode.GenericParameters[genericParameter.Position];
                        }
                        else
                        {
                            var declaringMethod1 = genericParameter.DeclaringMethod;

                            var methodDefinition = declaringMethod1.Resolve();

                            genericParameter = methodDefinition.GenericParameters[genericParameter.Position];

                            return Ensure(model, genericParameter, null);
 
                        }
                    }
                }
                case 0x02000000: // TypeDef
                {
                    TypeDefinition typeDefintion = (TypeDefinition)typeReference;

                    structuralAssembly = Infrastructure.Structural.Metadata.Assemblies.Ensuring.Ensure(model, typeDefintion.Module.Assembly.FullName);

                    var structuralModuleNode = Infrastructure.Structural.Metadata.Modules.Ensure(model, structuralAssembly, typeDefintion.Module.Mvid);

                    return LookupStructuralTypeNode(structuralModuleNode, tableId, rowId); 
                }
                
                default:
                    throw new Exception("Should not happen.");
            }


        }

        private StructuralModuleNode GetModuleNode(RuntimicSystemModel model, TypeReference typeReference)
        {
            if (typeReference.IsPointer)
            {
                return GetModuleNode(model, typeReference.GetElementType());
            }

            if (typeReference.IsByReference)
            {
                return GetModuleNode(model, typeReference.GetElementType());
            }

            if (typeReference.IsArray)
            {
                return GetModuleNode(model, typeReference.GetElementType());
            }

            if (typeReference.IsGenericInstance)
            {
                return GetModuleNode(model, typeReference.GetElementType());
            }

            if (typeReference.IsGenericParameter)
            {
                
                var parameter = (GenericParameter) typeReference;

                if (parameter.Type == GenericParameterType.Type)
                {
                    return GetModuleNode(model, parameter.DeclaringType);
                }
                else
                {
                    var methodDefintion = parameter.DeclaringMethod.Resolve();

                    return GetModuleNode(model, methodDefintion.DeclaringType);
                }
                
            }

            var scope = typeReference.Scope;

            if (scope.MetadataScopeType == MetadataScopeType.AssemblyNameReference)
            {
                AssemblyNameReference reference = (AssemblyNameReference) scope;

                var assemblyEntry = Infrastructure.Structural.Metadata.Assemblies.Ensuring.Ensure(model, reference);

                var types  = assemblyEntry.Types;

                var type = types[typeReference.FullName];

                return type.Module;
            }
            if (scope.MetadataScopeType == MetadataScopeType.ModuleDefinition)
            {
                var moduleDefinition = (ModuleDefinition) scope;

                return Infrastructure.Structural.Metadata.Modules.Get(model, moduleDefinition.Mvid);
            }
            if (scope.MetadataScopeType == MetadataScopeType.ModuleReference)
            {
                throw new Exception("Not Implemented");
            }
            throw new Exception("Not Implemented");

        }

        private StructuralTypeNode LookupStructuralTypeNode(StructuralModuleNode structuralModuleNode, int tableId, int rowId)
        {
            if (!structuralModuleNode.Tables.TryGetValue(tableId, out StructuralTypeTable table))
            {
                throw new Exception("Expected type definition to already be loaded.");
            }

            if (!table.ByRow.TryGetValue((uint)rowId, out StructuralTypeNode structuralTypeNode))
            {
                throw new Exception("Expected type definition to already be loaded.");
            }

            return structuralTypeNode;
        }

        public StructuralTypeNode Ensure(RuntimicSystemModel runtimicSystemModel, StructuralModuleNode structuralModuleNode, TypeReference typeReference)
        {
            var metadataToken = typeReference.MetadataToken.ToInt32();

            var tableId = (int)(metadataToken & 0xFF000000);

            var rowId = metadataToken & 0x00FFFFFF;

            bool isDerived = rowId < 1;

            if (!structuralModuleNode.Tables.TryGetValue(tableId, out StructuralTypeTable table))
            {
                table = new StructuralTypeTable();

                structuralModuleNode.Tables.Add(tableId, table);
            }

            if (table.ByRow.TryGetValue((uint)rowId, out StructuralTypeNode structuralTypeNode))
            {
                return structuralTypeNode;
            }

            structuralTypeNode = new StructuralTypeNode()
            {
                CecilTypeReference = typeReference,
                MetadataToken = metadataToken,
                Module = structuralModuleNode,
                IsDerived = isDerived,
                FullName = typeReference.FullName ?? typeReference.Name,
                IsGenericParameter = typeReference.IsGenericParameter
            };

            if (typeReference.IsDefinition)
            {
                var typeDefinition = (TypeDefinition) typeReference;

                structuralTypeNode.GenericParameters = new StructuralTypeNode[typeDefinition.GenericParameters.Count];

                for (int i = 0; i < typeDefinition.GenericParameters.Count; i++)
                {
                    structuralTypeNode.GenericParameters[i] = Ensure(runtimicSystemModel, structuralModuleNode, typeDefinition.GenericParameters[i]);
                }

                for (int i = 0; i < typeDefinition.Methods.Count; i++)
                {
                    var method = typeDefinition.Methods[i];

                    for (int j = 0; j < method.GenericParameters.Count; j++)
                    {
                        Ensure(runtimicSystemModel, structuralModuleNode, method.GenericParameters[j]);
                    }
                }
            }

           

            table.ByRow.Add((uint)rowId, structuralTypeNode);

            return structuralTypeNode;
        }

        private void SetNode(StructuralTypeNode genericDefinitionStemType, StructuralGenericInstanceTypeNode node)
        {
            if (genericDefinitionStemType.GenericInstances == null)

            {
                genericDefinitionStemType.GenericInstances = new StructuralGenericInstanceTypeNode[5];
            }

            var foundSlot = false;
            int currentIndex = 0;

            for (; currentIndex < genericDefinitionStemType.GenericInstances.Length; currentIndex++)
            {
                var arrayNode = genericDefinitionStemType.GenericInstances[currentIndex];

                if (arrayNode == null)
                {
                    foundSlot = true;
                    break;
                }
            }

            if (!foundSlot)
            {
                var tempArrays = new StructuralGenericInstanceTypeNode[genericDefinitionStemType.GenericInstances.Length + 5];

                Array.Copy(genericDefinitionStemType.GenericInstances, 0, tempArrays, 0, genericDefinitionStemType.GenericInstances.Length);

                genericDefinitionStemType.GenericInstances = tempArrays;
            }

            genericDefinitionStemType.GenericInstances[currentIndex] = node;
        }

        private bool CheckForBranch(StructuralTypeNode blueprintNode, StructuralTypeNode[] typeArguments, out StructuralGenericInstanceTypeNode executionTypeNode)
        {
            executionTypeNode = null;

            var generics = blueprintNode.GenericInstances;

            if (generics == null) return false;

            for (int i = 0; i < generics.Length; i++)
            {
                var genericInstanceNode = generics[i];

                if (genericInstanceNode?.GenericArguments?.Length != typeArguments.Length) continue;

                var ok = true;

                for (var j = 0; j < genericInstanceNode.GenericArguments.Length; j++)
                {
                    var argument = genericInstanceNode.GenericArguments[j];

                    if (ReferenceEquals(argument, typeArguments[j])) continue;

                    ok = false;

                    break;
                }

                if (!ok) continue;

                executionTypeNode = genericInstanceNode;

                return true;
            }

            return false;
        }
    }
}
