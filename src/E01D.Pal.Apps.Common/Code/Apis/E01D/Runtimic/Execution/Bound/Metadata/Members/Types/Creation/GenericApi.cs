using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation
{
	public class GenericApi<TContainer> : BoundApiNode<TContainer>, GenericApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
        

        //public BoundTypeMask_I Create(SemanticModelMask_I semanticModel, BoundModuleMask_I moduleEntry, GenericInstanceType typeDefinition)
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

        //    //if (typeDefinitionEntry.SupportsBaseType() && typeDefinitionEntry is BoundTypeWithBaseType_I chbt)
        //    //{
        //    //    chbt.BaseType = Types.BaseTypes.GetBaseType(semanticModel, moduleEntry, typeDefinition);

        //    //    if (chbt.BaseType != null)
        //    //    {
        //    //        Types.Dependencies.Add(typeDefinitionEntry, chbt.BaseType);
        //    //    }
        //    //}

        //    //if (typeDefinitionEntry.SupportsInterfaceTypeList() && typeDefinitionEntry is BoundTypeWithInterfaceTypeList_I tewii)
        //    //{
        //    //    tewii.Interfaces = Types.Interfaces.GetInterfaces(semanticModel, typeDefinition);

        //    //    var list = tewii.Interfaces.ByResolutionName.Values.ToList();

        //    //    for (var i = 0; i < list.Count; i++)
        //    //    {
        //    //        var item = list[i];

        //    //        Types.Dependencies.Add(typeDefinitionEntry, item.BaseType);
        //    //    }
        //    //}

        //    //if (typeDefinition.NestedTypes != null && typeDefinition.NestedTypes.Count > 0)
        //    //{
        //    //    var list = typeDefinition.NestedTypes;

        //    //    for (var i = 0; i < list.Count; i++)
        //    //    {
        //    //        var item = list[i];

        //    //        var nestedClass = Types.Ensuring.Ensure(semanticModel, moduleEntry, item);

        //    //        var btwdt = (BoundTypeWithDeclaringType_I)nestedClass;

        //    //        btwdt.DeclaringType = typeDefinitionEntry;

        //    //        Types.Dependencies.Add(nestedClass, typeDefinitionEntry);

        //    //        typeDefinitionEntry.NestedTypes.Add(nestedClass.ResolutionName(), nestedClass);
        //    //    }
        //    //}

        //    BuildOutTypeParameters(semanticModel, moduleEntry, typeDefinitionEntry);

        //    return typeDefinitionEntry;
        //}

        //public void BuildOutTypeParameters(SemanticModelMask_I semanticModel, BoundModuleMask_I moduleEntry, BoundTypeDefinitionMask_I typeDefinitionEntry)
        //{
        //    var typeDefinition = typeDefinitionEntry.TypeDefinition;

        //    if (!typeDefinition.HasGenericParameters) return;

        //    var gtd = (BoundGenericTypeDefinition_I)typeDefinitionEntry;

        //    var typeParameters = typeDefinition.GenericParameters;

        //    for (var i = 0; i < typeParameters.Count; i++)
        //    {
        //        var typeParematerDefinition = typeParameters[i];

        //        var ctpd = new BoundTypeParameterDefinition()
        //        {
        //            DeclaringTypeDefinitionEntry = (BoundTypeDefinition)typeDefinitionEntry,
        //            GenericParameterDefinition = typeParematerDefinition,
        //            FullName = typeDefinition.FullName + "`" + typeParematerDefinition.Name,
        //            Name = typeParematerDefinition.Name
        //        };

        //        gtd.TypeParameters.Add(ctpd.Name, ctpd);

        //        Types.Dependencies.Add(typeDefinitionEntry, ctpd);

        //        for (var j = 0; j < typeParematerDefinition.Constraints.Count; j++)
        //        {
        //            var constraintTypeReference = typeParematerDefinition.Constraints[j];

        //            if (!constraintTypeReference.IsDefinition)
        //            {
        //                throw new System.Exception("Not a definition. Add type resolution.");
        //            }

        //            var constraintTypeDefinition = (TypeDefinition)constraintTypeReference;

        //            var constraintTypeDefinitionEntry = Types.Ensuring.Ensure(semanticModel, moduleEntry, constraintTypeDefinition);

        //            if (constraintTypeDefinition.IsClass)
        //            {
        //                var constraint = new BoundClassTypeParameterConstraint
        //                {
        //                    Class = constraintTypeDefinitionEntry
        //                };

        //                ctpd.BaseTypeConstraint = constraint;

        //                Types.Dependencies.Add(typeDefinitionEntry, constraint.Class);
        //            }
        //            else if (constraintTypeDefinition.IsInterface)
        //            {
        //                var constraint = new BoundInterfaceTypeParameterConstraint
        //                {
        //                    Interface = constraintTypeDefinitionEntry
        //                };

        //                ctpd.InterfaceTypeConstraints.Add(constraintTypeDefinitionEntry.FullName, constraint);

        //                Types.Dependencies.Add(typeDefinitionEntry, constraint.Interface);
        //            }
        //            else
        //            {
        //                throw new System.Exception("Not a class or interface.");
        //            }
        //        }
        //    }
        //}

        
    }
}
