using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation
{
	public class DefinitionApi<TContainer> : BoundApiNode<TContainer>, DefinitionApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {

        //public BoundTypeDefinitionMask_I Create(SemanticModelMask_I semanticModel, BoundModuleMask_I moduleEntry, TypeDefinition typeDefinition)
        //{
        //    //if (conversion.Model.Types.SimpleTypes.TryGetValue(typeDefinition.FullName, out ConvertedSimpleClTypeDefinition simple))
        //    //{
        //    //    return simple;
        //    //}

        //    var typeDefinitionEntry = CreateTypeDefinitionEntry(moduleEntry, typeDefinition);

        //    if (typeDefinition.IsFunctionPointer)
        //    {

        //    }

        //    // https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables

        //    if (typeDefinitionEntry.SupportsBaseType() && typeDefinitionEntry is BoundTypeWithBaseType_I chbt)
        //    {
        //        chbt.BaseType = Types.BaseTypes.GetBaseType(semanticModel, moduleEntry, typeDefinition);

        //        if (chbt.BaseType != null)
        //        {
        //            Types.Dependencies.Add(typeDefinitionEntry, chbt.BaseType);
        //        }
        //    }

        //    if (typeDefinitionEntry.SupportsInterfaceTypeList() && typeDefinitionEntry is BoundTypeWithInterfaceTypeList_I tewii)
        //    {
        //        tewii.Interfaces = Types.Interfaces.GetInterfaces(semanticModel, typeDefinition);

        //        var list = tewii.Interfaces.ByResolutionName.Values.ToList();

        //        for (var i = 0; i < list.Count; i++)
        //        {
        //            var item = list[i];

        //            Types.Dependencies.Add(typeDefinitionEntry, item.BaseType);
        //        }
        //    }

        //    if (typeDefinition.NestedTypes != null && typeDefinition.NestedTypes.Count > 0)
        //    {
        //        var list = typeDefinition.NestedTypes;

        //        for (var i = 0; i < list.Count; i++)
        //        {
        //            var item = list[i];

        //            var nestedClass = Types.Ensuring.Ensure(semanticModel, moduleEntry, item);

        //            var btwdt = (BoundTypeWithDeclaringType_I)nestedClass;

        //            btwdt.DeclaringType = typeDefinitionEntry;

        //            Types.Dependencies.Add(nestedClass, typeDefinitionEntry);

        //            typeDefinitionEntry.NestedTypes.Add(nestedClass.ResolutionName(), nestedClass);
        //        }
        //    }

        //    BuildOutTypeParameters(semanticModel, moduleEntry, typeDefinitionEntry);

        //    return typeDefinitionEntry;
        //}

        

        //private BoundTypeDefinitionMask_I CreateTypeDefinitionEntry(BoundModuleMask_I moduleEntry, TypeDefinition typeDefinition)
        //{
           

        //    var convertedModule = moduleEntry as BoundModule_I;

        //    BoundTypeDefinition boundTypeDefinition;

        //    if (typeDefinition.HasGenericParameters)
        //    {
        //        if (typeDefinition.IsNested)
        //        {
        //            if (typeDefinition.IsValueType) // needs to be before 
        //            {
        //                if (IsSimpleType(typeDefinition.FullName))
        //                {
        //                    throw new System.Exception("Not implemented.");
        //                }
        //                if (typeDefinition.IsEnum)
        //                {
        //                    throw new System.Exception("Not expected");
        //                }
        //                else
        //                {
        //                    boundTypeDefinition = new BoundGenericNestedStructTypeDefinition();
        //                }
        //            }
        //            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
        //            {
        //                boundTypeDefinition = new BoundGenericNestedDelegateTypeDefinition();
        //            }
        //            else if (typeDefinition.IsArray)
        //            {
        //                boundTypeDefinition = new BoundGenericNestedArrayTypeDefinition();

        //            }
        //            else if (typeDefinition.IsClass)
        //            {
        //                boundTypeDefinition = new BoundGenericNestedClassTypeDefinition();

        //            }
        //            else if (typeDefinition.IsInterface)
        //            {
        //                boundTypeDefinition = new BoundGenericNestedInterfaceTypeDefinition();
        //            }
        //            else
        //            {
        //                throw new System.NotImplementedException();
        //            }
        //        }
        //        else
        //        {
        //            if (typeDefinition.IsValueType) // needs to be before 
        //            {
        //                if (IsSimpleType(typeDefinition.FullName))
        //                {
        //                    throw new System.Exception("Not implemented.");
        //                }

        //                else if (typeDefinition.IsEnum)
        //                {
        //                    throw new System.Exception("Not expected");
        //                }
        //                else
        //                {
        //                    boundTypeDefinition = new BoundGenericStructTypeDefinition();
        //                }
        //            }
        //            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
        //            {
        //                boundTypeDefinition = new BoundGenericDelegateTypeDefinition();
        //            }
        //            else if (typeDefinition.IsArray)
        //            {
        //                throw new System.Exception("Not expected");

        //            }
        //            else if (typeDefinition.IsClass)
        //            {
        //                boundTypeDefinition = new BoundGenericClassTypeDefinition();

        //            }
        //            else if (typeDefinition.IsInterface)
        //            {
        //                boundTypeDefinition = new BoundGenericInterfaceTypeDefinition();
        //            }
        //            else
        //            {
        //                throw new System.NotImplementedException();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (typeDefinition.IsNested)
        //        {
        //            if (typeDefinition.IsValueType) // needs to be before 
        //            {
        //                if (IsSimpleType(typeDefinition.FullName))
        //                {
        //                    throw new System.Exception("Not expected");
        //                }
        //                if (typeDefinition.IsEnum)
        //                {
        //                    boundTypeDefinition = new BoundNestedEnumTypeDefinition();
        //                }
        //                else
        //                {
        //                    boundTypeDefinition = new BoundNestedStructTypeDefinition();
        //                }
        //            }
        //            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
        //            {
        //                boundTypeDefinition = new BoundNestedDelegateTypeDefinition();
        //            }
        //            else if (typeDefinition.IsArray)
        //            {
        //                boundTypeDefinition = new BoundNestedArrayTypeDefinition();

        //            }
        //            else if (typeDefinition.IsClass)
        //            {
        //                boundTypeDefinition = new BoundNestedClassTypeDefinition();

        //            }
        //            else if (typeDefinition.IsInterface)
        //            {
        //                boundTypeDefinition = new BoundNestedInterfaceTypeDefinition();
        //            }
        //            else
        //            {
        //                throw new System.NotImplementedException();
        //            }
        //        }
        //        else
        //        {
        //            if (typeDefinition.IsValueType) // needs to be before 
        //            {
        //                if (IsSimpleType(typeDefinition.FullName))
        //                {
        //                    boundTypeDefinition = new BoundSimpleClTypeDefinition();
        //                }

        //                else if (typeDefinition.IsEnum)
        //                {
        //                    boundTypeDefinition = new BoundEnumTypeDefinition();
        //                }
        //                else
        //                {
        //                    boundTypeDefinition = new BoundStructTypeDefinition();
        //                }
        //            }
        //            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
        //            {
        //                boundTypeDefinition = new BoundDelegateTypeDefinition();
        //            }
        //            else if (typeDefinition.IsArray)
        //            {
        //                boundTypeDefinition = new BoundArrayTypeDefinition();

        //            }
        //            else if (typeDefinition.IsClass)
        //            {
        //                boundTypeDefinition = new BoundClassTypeDefinition();

                        

        //            }
        //            else if (typeDefinition.IsInterface)
        //            {
        //                boundTypeDefinition = new BoundInterfaceTypeDefinition();
        //            }
        //            else
        //            {
        //                throw new System.NotImplementedException();
        //            }
        //        }
        //    }



        //    boundTypeDefinition.TypeReference = typeDefinition;
        //    boundTypeDefinition.FullName = typeDefinition.FullName;
        //    boundTypeDefinition.Name = typeDefinition.Name;
        //    boundTypeDefinition.Module = convertedModule;
        //    boundTypeDefinition.PackingSize = GetPackingSize(typeDefinition);

        //    if (typeDefinition.MetadataToken.RID == 1)
        //    {
        //        boundTypeDefinition.TypeKind |= Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal.TypeKind.Global;
        //    }

        //    return boundTypeDefinition;
        //}

        private bool IsSimpleType(string typeDefinitionFullName)
        {
            return Binding.Metadata.Members.Types.Simple.IsSimpleType(typeDefinitionFullName);
        }


        public System.Reflection.Emit.PackingSize GetPackingSize(TypeDefinition typeDefinition)
        {
            return Cecil.GetPackingSize(typeDefinition);
        }

    }
}
