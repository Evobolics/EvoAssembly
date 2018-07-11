using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation
{
    public class DotNetApi<TContainer> : SemanticApiNode<TContainer>, DotNetApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {

        public SemanticTypeDefinition CreateType(InfrastructureModelMask_I model, SemanticModuleMask_I moduleEntry, System.Type typeReference)
        {
            //var convertedType = (SemanticTypeDefinition)this.Infrastructure.Semantic.Metadata.Members.Types.Creation.CreateType
            //<SemanticGenericArrayTypeDefinition,
            //    SemanticGenericStructTypeDefinition,
            //    SemanticGenericDelegateTypeDefinition,
            //    SemanticGenericClassTypeDefinition,
            //    SemanticGenericInterfaceTypeDefinition,
            //    SemanticGenericNestedStructTypeDefinition,
            //    SemanticGenericNestedDelegateTypeDefinition,
            //    SemanticGenericNestedArrayTypeDefinition,
            //    SemanticGenericNestedClassTypeDefinition,
            //    SemanticGenericNestedInterfaceTypeDefinition,
            //    SemanticNestedEnumTypeDefinition,
            //    SemanticNestedStructTypeDefinition,
            //    SemanticNestedDelegateTypeDefinition,
            //    SemanticNestedArrayTypeDefinition,
            //    SemanticNestedClassTypeDefinition,
            //    SemanticNestedInterfaceTypeDefinition,
            //    SemanticSimpleClTypeDefinition,
            //    SemanticEnumTypeDefinition,
            //    SemanticStructTypeDefinition,
            //    SemanticDelegateTypeDefinition,
            //    SemanticArrayTypeDefinition,
            //    SemanticClassTypeDefinition,
            //    SemanticInterfaceTypeDefinition>(model, moduleEntry, typeReference);



            throw new System.NotImplementedException();
        }
    }
}
