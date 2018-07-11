using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation
{
	public class CreationApi<TContainer> : BindingApiNode<TContainer>, CreationApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
		public DefinitionApi<TContainer> Definitions { get; set; }

		public GenericApi<TContainer> Generics { get; set; }

		public ReferenceApi<TContainer> References { get; set; }
	    

	    DefinitionApiMask_I CreationApiMask_I.Definitions => Definitions;

        GenericApiMask_I CreationApiMask_I.Generics => Generics;

        ReferenceApiMask_I CreationApiMask_I.References => References;

        public BoundTypeDefinition Create(InfrastructureModelMask_I model, ModuleDefinition sourceModule, BoundModule_I boundModule, System.Type type)
        {
            var typeInformation = Infrastructure.Semantic.Metadata.Members.Types.Information.CreateTypeInformation(model, type);

            var bound = CreateFactory(typeInformation);

            CreatePost(bound, sourceModule, boundModule, typeInformation, type);

            return bound;
        }
        
        public BoundTypeDefinition Create(InfrastructureModelMask_I model, ModuleDefinition sourceModule, BoundModule_I boundModule, TypeReference typeReference, System.Type underlyingType)
        {
	        if (typeReference.FullName == "System.Xml.Xsl.Xslt.CompilerScopeManager`1/ScopeFlags<V>")
	        {
		        
	        }

            var typeInformation = Infrastructure.Semantic.Metadata.Members.Types.Information.CreateTypeInformation(model, typeReference);

            var bound = CreateFactory(typeInformation);

            CreatePost(bound, sourceModule, boundModule, typeInformation, underlyingType);

            return bound;
        }

        public BoundTypeDefinition CreateFactory(SemanticTypeInformation typeInformation)
        {
            return (BoundTypeDefinition)this.Infrastructure.Semantic.Metadata.Members.Types.Creation.Factory.CreateType
            <
                BoundGenericStructTypeDefinition,
                BoundGenericDelegateTypeDefinition,
                BoundGenericClassTypeDefinition,
                BoundGenericInterfaceTypeDefinition,
                BoundGenericNestedStructTypeDefinition,
                BoundGenericNestedDelegateTypeDefinition,
                
                BoundGenericNestedClassTypeDefinition,
                BoundGenericNestedInterfaceTypeDefinition,
                BoundNestedEnumTypeDefinition,
                BoundNestedStructTypeDefinition,
                BoundNestedDelegateTypeDefinition,
                
                BoundNestedClassTypeDefinition,
                BoundNestedInterfaceTypeDefinition,
                BoundSimpleClTypeDefinition,
                BoundEnumTypeDefinition,
                BoundStructTypeDefinition,
                BoundDelegateTypeDefinition,
                BoundArrayTypeDefinition,
                BoundClassTypeDefinition,
                BoundInterfaceTypeDefinition,
				BoundPointerTypeDefinition,
				BoundRequiredModifierTypeDefinition>(typeInformation);
        }

        public void CreatePost(BoundTypeDefinition bound, ModuleDefinition sourceModule, BoundModuleMask_I semanticModule, SemanticTypeInformation typeInformation, System.Type underlyingType)
        {
            if (bound.IsGeneric())
            {
                var generic = (BoundGenericTypeDefinition_I)bound;

	            generic.GenericKind = typeInformation.GenericKind;

	            generic.SourceGenericInstanceType = typeInformation.GenericInstanceType;

				if (typeInformation.GenericTypeDefinition == null)
                {
                    if (typeInformation.IsClosedGeneric && !typeInformation.IsAnonymousType)
                    {
                        throw new System.Exception("Expected a generic type definition");
                    }
                }

                
            }

			

	        bound.AssemblyQualifiedName = Cecil.Metadata.Members.Types.Naming.GetAssemblyQualifiedName(typeInformation.TypeReference);
			bound.FullName = typeInformation.FullName;
            bound.Name = typeInformation.Name;
            bound.SourceModuleDefinition = sourceModule;
            bound.Module = semanticModule;
            bound.PackingSize = typeInformation.PackingSize;
	        bound.SourceTypeReference = typeInformation.TypeReference;
			bound.UnderlyingType = underlyingType;

            if (typeInformation.IsGlobal)
            {
                bound.TypeKind |= Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal.TypeKind.Global;
            }
        }



        

        //private bool IsSimpleType(string typeDefinitionFullName)
        //{
        //    return Binding.Metadata.Members.Types.Simple.IsSimpleType(typeDefinitionFullName);
        //}


        //public System.Reflection.Emit.PackingSize GetPackingSize(TypeDefinition typeDefinition)
        //{
        //    return Binding.Metadata.Members.Types.Definitions.GetPackingSize(typeDefinition);
        //}

        public BoundTypeDefinitionMask_I CreateTypeDefinitionEntry(SemanticModuleMask_I moduleEntry, TypeDefinition typeDefinition)
        {
            throw new System.NotImplementedException();
        }

        //public BoundTypeMask_I CreateEntry(SemanticModelMask_I semanticModel, TypeReference input)
        //{
        //    // Get the module for the type creation.  If the type is orginal or mscorlib, then treated specially.
        //    var moduleEntry = Modules.Ensuring.EnsureModuleFromAssembly(semanticModel, input);

        //    return CreateEntry(semanticModel, moduleEntry, input);

        //}

        //public BoundTypeMask_I CreateEntry(SemanticModelMask_I semanticModel, SemanticModuleMask_I moduleEntry, TypeReference typeDefinition, System.Type type)
        //{
        //    var typeDefinitionEntry = CreateType(semanticModel, moduleEntry, typeDefinition, type);

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

        //    //BuildOutTypeParameters(semanticModel, moduleEntry, typeDefinitionEntry);

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
        //            Definition = typeParematerDefinition,
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
        //                throw new System.Exception("Not a definition. Add type resolution.");
        //            }

        //            var constraintTypeDefinition = (TypeDefinition)constraintTypeReference;

        //            var constraintTypeDefinitionEntry = Types.Ensuring.EnsureBoundType(semanticModel, moduleEntry, constraintTypeDefinition);

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
