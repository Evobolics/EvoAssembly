using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Creation
{
	public class CreationApi<TContainer> : BoundApiNode<TContainer>, CreationApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
		public DefinitionApi<TContainer> Definitions { get; set; }

		public GenericApi<TContainer> Generics { get; set; }

		public ReferenceApi<TContainer> References { get; set; }
	    

	    DefinitionApiMask_I CreationApiMask_I.Definitions => Definitions;

        GenericApiMask_I CreationApiMask_I.Generics => Generics;

        ReferenceApiMask_I CreationApiMask_I.References => References;

        public BoundTypeDefinition Create(InfrastructureRuntimicModelMask_I model, System.Type type)
        {
            var typeInformation = Infrastructure.Semantic.Metadata.Members.Types.Information.CreateTypeInformation(model, type);

            var bound = CreateFactory(typeInformation);

            CreatePost(bound, typeInformation, type);

            return bound;
        }
        
        public BoundTypeDefinition Create(InfrastructureRuntimicModelMask_I model, TypeReference typeReference, System.Type underlyingType)
        {
	        

            var typeInformation = Infrastructure.Semantic.Metadata.Members.Types.Information.CreateTypeInformation(model, typeReference);

            var bound = CreateFactory(typeInformation);

            CreatePost(bound, typeInformation, underlyingType);

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

        public void CreatePost(BoundTypeDefinition bound, SemanticTypeInformation typeInformation, System.Type underlyingType)
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
            
            
            bound.PackingSize = typeInformation.PackingSize;
	        bound.SourceTypeReference = typeInformation.TypeReference;
			bound.UnderlyingType = underlyingType;

            if (typeInformation.IsGlobal)
            {
                bound.TypeKind |= Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal.TypeKind.Global;
            }
        }



        

        

        

        
    }
}
