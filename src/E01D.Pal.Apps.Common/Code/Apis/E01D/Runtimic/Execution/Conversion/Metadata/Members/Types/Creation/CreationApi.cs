using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Creation
{
	public class CreationApi<TContainer> : ConversionApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {

        

        public DotNetApi<TContainer> DotNet { get; set; }

        public DefinitionApi<TContainer> Definitions { get; set; }

		public GenericApi<TContainer> Generics { get; set; }

		public ReferenceApi<TContainer> References { get; set; }

        

        DotNetApiMask_I CreationApiMask_I.DotNet => DotNet;

        DefinitionApiMask_I CreationApiMask_I.Definitions => Definitions;

        GenericApiMask_I CreationApiMask_I.Generics => Generics;

        ReferenceApiMask_I CreationApiMask_I.References => References;

        public ConvertedTypeDefinition Create(RuntimicSystemModel model, System.Type type)
        {


            var typeInformation = Infrastructure.Semantic.Metadata.Members.Types.Information.CreateTypeInformation(model, type);

            var converted = CreateFactory(typeInformation);

            CreatePost(converted, typeInformation);

            return converted;
        }

        public ConvertedTypeDefinition Create(RuntimicSystemModel model, TypeReference typeReference)
        {


            var typeInformation = Infrastructure.Semantic.Metadata.Members.Types.Information.CreateTypeInformation(model, typeReference);

            var converted = CreateFactory(typeInformation);

            CreatePost(converted, typeInformation);

            return converted;
        }

        public ConvertedTypeDefinition CreateFactory(SemanticTypeInformation typeInformation)
        {
            return (ConvertedTypeDefinition)this.Infrastructure.Semantic.Metadata.Members.Types.Creation.Factory.CreateType<
                ConvertedGenericStructTypeDefinition,
                ConvertedGenericDelegateTypeDefinition,
                ConvertedGenericClassTypeDefinition,
                ConvertedGenericInterfaceTypeDefinition,
                ConvertedGenericNestedStructTypeDefinition,
                ConvertedGenericNestedDelegateTypeDefinition,
                
                ConvertedGenericNestedClassTypeDefinition,
                ConvertedGenericNestedInterfaceTypeDefinition,
                ConvertedNestedEnumTypeDefinition,
                ConvertedNestedStructTypeDefinition,
                ConvertedNestedDelegateTypeDefinition,
                
                ConvertedNestedClassTypeDefinition,
                ConvertedNestedInterfaceTypeDefinition,
                ConvertedSimpleClTypeDefinition,
                ConvertedEnumTypeDefinition,
                ConvertedStructTypeDefinition,
                ConvertedDelegateTypeDefinition,
                ConvertedArrayTypeDefinition,
                ConvertedClassTypeDefinition,
                ConvertedInterfaceTypeDefinition,
	            ConvertedPointerTypeDefinition,
	            ConvertedRequiredModifierTypeDefinition>(typeInformation);
        }

        public void CreatePost(ConvertedTypeDefinition converted, SemanticTypeInformation typeInformation)
        {
            

            if (converted.IsGeneric())
            {
                var generic = (ConvertedGenericTypeDefinition_I)converted;

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


	        converted.AssemblyQualifiedName = Cecil.Metadata.Members.Types.Naming.GetAssemblyQualifiedName(typeInformation.TypeReference);
			converted.FullName = typeInformation.FullName;
            converted.Name = typeInformation.Name;
            converted.PackingSize = typeInformation.PackingSize;
            converted.SourceTypeReference = typeInformation.TypeReference;
	        converted.ResolutionName = Types.Naming.GetResolutionName(converted);
            if (typeInformation.IsGlobal)
            {
                converted.TypeKind |= Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal.TypeKind.Global;
            }
        }

        


    }
}
