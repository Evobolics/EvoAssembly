using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
	public class DefinitionApi<TContainer> : ConversionApiNode<TContainer>, DefinitionApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
		//public BoundTypeDefinitionMask_I Create(ILConversion conversion, BoundModuleMask_I moduleEntry, TypeDefinition typeDefinition)
		//{
		//    var typeDefinitionEntry = CreateTypeDefinitionEntry(moduleEntry, typeDefinition);

  //          // https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables

  //          if (typeDefinitionEntry.SupportsBaseType() && typeDefinitionEntry is BoundTypeWithBaseType_I chbt)
		//	{
		//		chbt.BaseType = Types.BaseTypes.GetBaseType(conversion, moduleEntry, typeDefinition);

		//	    if (chbt.BaseType != null)
		//	    {
		//	        Types.Dependencies.Add(typeDefinitionEntry, chbt.BaseType);
		//	    }
		//	}

		//	if (typeDefinitionEntry.SupportsInterfaceTypeList() && typeDefinitionEntry is BoundTypeWithInterfaceTypeList_I tewii)
		//	{
		//		tewii.Interfaces = Types.Interfaces.GetInterfaces(conversion, typeDefinition);

		//	    var list = tewii.Interfaces.ByResolutionName.Values.ToList();

		//	    for (var i = 0; i < list.Count; i++)
		//	    {
		//	        var item = list[i];

  //                  //Types.Dependencies.Add(typeDefinitionEntry, item.BaseType);
		//	    }
		//	}

		//    if (typeDefinition.NestedTypes != null && typeDefinition.NestedTypes.Count > 0)
		//    {
		//        var list = typeDefinition.NestedTypes;

  //              for (var i = 0; i < list.Count; i++)
		//        {
		//            var item = list[i];

		//            var nestedClass = Types.Ensuring.EnsureType(conversion, item);

		//            var btwdt  = (ConvertedTypeDefinitionWithDeclaringType_I)nestedClass;

		//            btwdt.DeclaringType = typeDefinitionEntry;

  //                  Types.Dependencies.Add(nestedClass, typeDefinitionEntry);

		//            typeDefinitionEntry.NestedTypes.Add(nestedClass.ResolutionName(), nestedClass);
		//        }
  //          }

		//    BuildOutTypeParameters(conversion, moduleEntry, typeDefinitionEntry);

  //          return typeDefinitionEntry;
		//}

        //public void BuildOutTypeParameters(ILConversion conversion, BoundModuleMask_I moduleEntry, BoundTypeDefinitionMask_I typeDefinitionEntry)
        //{
        //    var typeDefinition = typeDefinitionEntry.TypeDefinition;

        //    if (!typeDefinition.HasGenericParameters) return;

        //    var gtd = (ConvertedGenericTypeDefinition_I)typeDefinitionEntry;

        //    var typeParameters = typeDefinition.GenericParameters;

        //    for (var i = 0; i < typeParameters.Count; i++)
        //    {
        //        var typeParematerDefinition = typeParameters[i];

        //        var ctpd = new ConvertedTypeParameterDefinition()
        //        {
        //            DeclaringTypeDefinitionEntry = (ConvertedTypeDefinition)typeDefinitionEntry,
        //            GenericParameterDefinition = typeParematerDefinition,
        //            FullName = typeDefinition.FullName + "`" + typeParematerDefinition.Name,
        //            Name = typeParematerDefinition.Name
        //        };

        //        gtd.TypeParameters.Add(ctpd);

        //        Types.Dependencies.Add(typeDefinitionEntry, ctpd);

        //        for (var j = 0; j < typeParematerDefinition.Constraints.Count; j++)
        //        {
        //            var constraintTypeReference = typeParematerDefinition.Constraints[j];

        //            if (!constraintTypeReference.IsDefinition)
        //            {
        //                throw new Exception("Not a definition. Add type resolution.");
        //            }

        //            var constraintTypeDefinition = (TypeDefinition)constraintTypeReference;

        //            var constraintTypeDefinitionEntry = Types.Ensuring.EnsureType(conversion, constraintTypeDefinition);

        //            if (!(constraintTypeDefinitionEntry is BoundTypeMask_I boundConstraintTypeDefinition))
        //            {
        //                throw new Exception("Expected ast least a bound type.");
        //            }

        //            if (constraintTypeDefinition.IsClass)
        //            {
        //                var constraint = new ConvertedClassTypeParameterConstraint
        //                {
        //                    Class = boundConstraintTypeDefinition
        //                };

        //                ctpd.BaseTypeConstraint = constraint;

        //                Types.Dependencies.Add(typeDefinitionEntry, constraint.Class);
        //            }
        //            else if (constraintTypeDefinition.IsInterface)
        //            {
        //                var constraint = new ConvertedInterfaceTypeParameterConstraint
        //                {
        //                    Interface = boundConstraintTypeDefinition
        //                };

        //                ctpd.InterfaceTypeConstraints.Add(constraint);

        //                Types.Dependencies.Add(typeDefinitionEntry, constraint.Interface);
        //            }
        //            else
        //            {
        //                throw new Exception("Not a class or interface.");
        //            }
        //        }
        //    }
        //}


  //      private BoundTypeDefinitionMask_I CreateTypeDefinitionEntry(BoundModuleMask_I moduleEntry, TypeDefinition typeDefinition)
		//{
		//    if (!moduleEntry.IsConverted())
		//    {
  //              // Off load this call to the binding call.
		//        return this.Binding.Metadata.Members.Types.Creation.CreateTypeDefinitionEntry(moduleEntry, typeDefinition);
		//    }

		//    var convertedModule = moduleEntry as ConvertedModule_I;

  //          ConvertedTypeDefinition boundTypeDefinition;

		//    if (typeDefinition.HasGenericParameters)
		//    {
		//        if (typeDefinition.IsNested)
		//        {
		//            if (typeDefinition.IsValueType) // needs to be before 
		//            {
		//                if (IsSimpleType(typeDefinition.FullName))
		//                {
		//                    throw new Exception("Not expected");
		//                }
		//                if (typeDefinition.IsEnum)
		//                {
		//                    throw new Exception("Not expected");
  //                      }
		//                else
		//                {
		//                    boundTypeDefinition = new ConvertedGenericNestedStructTypeDefinition();
		//                }
		//            }
		//            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
		//            {
		//                boundTypeDefinition = new ConvertedGenericNestedDelegateTypeDefinition();
		//            }
		//            else if (typeDefinition.IsArray)
		//            {
		//                boundTypeDefinition = new ConvertedGenericNestedArrayTypeDefinition();

		//            }
		//            else if (typeDefinition.IsClass)
		//            {
		//                boundTypeDefinition = new ConvertedGenericNestedClassTypeDefinition();

		//            }
		//            else if (typeDefinition.IsInterface)
		//            {
		//                boundTypeDefinition = new ConvertedGenericNestedInterfaceTypeDefinition();
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
		//                    throw new Exception("Not expected");
  //                      }

		//                else if (typeDefinition.IsEnum)
		//                {
		//                    throw new Exception("Not expected");
  //                      }
		//                else
		//                {
		//                    boundTypeDefinition = new ConvertedGenericStructTypeDefinition();
		//                }
		//            }
		//            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
		//            {
		//                boundTypeDefinition = new ConvertedGenericDelegateTypeDefinition();
		//            }
		//            else if (typeDefinition.IsArray)
		//            {
		//                throw new Exception("Not expected");

  //                  }
		//            else if (typeDefinition.IsClass)
		//            {
		//                boundTypeDefinition = new ConvertedGenericClassTypeDefinition();

		//            }
		//            else if (typeDefinition.IsInterface)
		//            {
		//                boundTypeDefinition = new ConvertedGenericInterfaceTypeDefinition();
		//            }
		//            else
		//            {
		//                throw new System.NotImplementedException();
		//            }
		//        }
  //          }
		//    else
		//    {
		//        if (typeDefinition.IsNested)
		//        {
		//            if (typeDefinition.IsValueType) // needs to be before 
		//            {
		//                if (IsSimpleType(typeDefinition.FullName))
		//                {
		//                    throw new Exception("Not expected");
		//                }
		//                if (typeDefinition.IsEnum)
		//                {
		//                    boundTypeDefinition = new ConvertedNestedEnumTypeDefinition();
		//                }
		//                else
		//                {
		//                    boundTypeDefinition = new ConvertedNestedStructTypeDefinition();
		//                }
		//            }
		//            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
		//            {
		//                boundTypeDefinition = new ConvertedNestedDelegateTypeDefinition();
		//            }
		//            else if (typeDefinition.IsArray)
		//            {
		//                boundTypeDefinition = new ConvertedNestedArrayTypeDefinition();

		//            }
		//            else if (typeDefinition.IsClass)
		//            {
		//                boundTypeDefinition = new ConvertedNestedClassTypeDefinition();

		//            }
		//            else if (typeDefinition.IsInterface)
		//            {
		//                boundTypeDefinition = new ConvertedNestedInterfaceTypeDefinition();
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
		//                    boundTypeDefinition = new ConvertedSimpleClTypeDefinition();
		//                }

		//                else if (typeDefinition.IsEnum)
		//                {
		//                    boundTypeDefinition = new ConvertedEnumTypeDefinition();
		//                }
		//                else
		//                {
		//                    boundTypeDefinition = new ConvertedStructTypeDefinition();
		//                }
		//            }
		//            else if (typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
		//            {
		//                boundTypeDefinition = new ConvertedDelegateTypeDefinition();
		//            }
		//            else if (typeDefinition.IsArray)
		//            {
		//                boundTypeDefinition = new ConvertedArrayTypeDefinition();

		//            }
		//            else if (typeDefinition.IsClass)
		//            {
		//                boundTypeDefinition = new ConvertedClassTypeDefinition();

		//            }
		//            else if (typeDefinition.IsInterface)
		//            {
		//                boundTypeDefinition = new ConvertedInterfaceTypeDefinition();
		//            }
		//            else
		//            {
		//                throw new System.NotImplementedException();
		//            }
		//        }
  //          }
		    
		    

		//    boundTypeDefinition.TypeDefinition = typeDefinition;
  //          boundTypeDefinition.FullName = typeDefinition.FullName;
		//    boundTypeDefinition.Module = convertedModule;
  //          boundTypeDefinition.PackingSize = GetPackingSize(typeDefinition);

		//    return boundTypeDefinition;
		//}

        //private bool IsSimpleType(string fullName)
        //{
        //    return Binding.Metadata.Members.Types.Simple.IsSimpleType(fullName);
        //}

        //private PackingSize GetPackingSize(TypeDefinition typeDefinition)
        //{
        //    return Binding.Metadata.Members.Types.Definitions.GetPackingSize(typeDefinition);
        //}

	    
	}
}
